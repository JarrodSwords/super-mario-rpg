using System.Linq;
using FluentAssertions;
using SuperMarioRpg.Domain;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Core

        private readonly Id _characterId;
        private readonly ICharacterRepository _characterRepository;

        public CharacterDefinitionSpec()
        {
            var result = Character.Define("Mario");
            var character = ((Result<Character>) result).Value;
            _characterId = character.Id;
            _characterRepository = new CharacterRepository().Create(character);
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
            var @event = (CharacterDefined) character.GetPendingEvents().Last();

            @event.Name.Should().Be(name);
            @event.Type.Should().Be(nameof(CharacterDefined));
        }

        [Theory]
        [InlineData("Mallow")]
        [InlineData("Geno")]
        public void WhenRenaming_CharacterRenamed(string name)
        {
            var character = _characterRepository
                .Find(_characterId)
                .Rename(name);

            var @event = (CharacterRenamed) character.GetPendingEvents().Last();

            @event.Name.Should().Be(name);
            @event.Type.Should().Be(nameof(CharacterRenamed));
        }

        #endregion
    }
}
