using System;
using System.Linq;
using FluentAssertions;
using SuperMarioRpg.Domain;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Core

        private readonly Character _character;

        public CharacterDefinitionSpec()
        {
            var result = Character.Define("Mario");
            var character = ((Result<Character>) result).Value;
            _character = new CharacterRepository()
                .Create(character)
                .Find(character.Id);
        }

        #endregion

        #region Private Interface

        private static void Assert<T>(
            IEventSourced aggregate,
            params Action<T>[] conditions
        ) where T : IEvent
        {
            var pendingEvents = aggregate.GetPendingEvents().ToList();
            pendingEvents.Should().ContainSingle(x => x.GetType() == typeof(T));

            var @event = pendingEvents.First(x => x.GetType() == typeof(T));
            foreach (var condition in conditions)
                condition.Invoke((T) @event);
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData("Mario")]
        [InlineData("Chancellor")]
        public void WhenDefiningCharacter_CharacterInitialized(string name)
        {
            var result = Character.Define(name);

            var character = ((Result<Character>) result).Value;

            Assert<CharacterDefined>(
                character,
                x => x.Name.Should().Be(name),
                x => x.Type.Should().Be(nameof(CharacterDefined))
            );
        }

        [Theory]
        [InlineData("Mallow")]
        [InlineData("Geno")]
        public void WhenRenaming_CharacterRenamed(string name)
        {
            _character.Rename(name);

            Assert<CharacterRenamed>(
                _character,
                x => x.Name.Should().Be(name),
                x => x.Type.Should().Be(nameof(CharacterRenamed))
            );
        }

        #endregion
    }
}
