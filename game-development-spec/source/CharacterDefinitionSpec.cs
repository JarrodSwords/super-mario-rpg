using System.Linq;
using FluentAssertions;
using SuperMarioRpg.Domain;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Test Methods

        [Fact]
        public void WhenDefiningCharacter_CharacterInitialized()
        {
            var result = Character.Define("Mario");

            var @event = ((Result<Character>) result).Value.PendingEvents.Last();

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
