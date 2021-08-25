using System.Linq;
using FluentAssertions;
using SuperMarioRpg.Domain;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Test Methods

        [Theory]
        [InlineData("Mario")]
        [InlineData("Chancellor")]
        public void WhenDefiningCharacter_CharacterInitialized(string name)
        {
            var result = Character.Define(name);

            var character = ((Result<Character>) result).Value;
            var @event = (CharacterDefined) character.PendingEvents.Last();

            @event.Name.Should().Be(name);
            @event.Type.Should().Be(nameof(CharacterDefined));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenDefiningCharacter_WithInvalidName_Fails(string name)
        {
            var result = Character.Define(name);

            result.WasFailure().Should().BeTrue();
        }

        #endregion
    }
}
