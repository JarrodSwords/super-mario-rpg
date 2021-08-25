using System.Linq;
using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Test Methods

        [Fact]
        public void WhenDefiningCharacter_CharacterInitialized()
        {
            var character = new Character("Mario");

            var @event = character.PendingEvents.Last();

            @event.Type.Should().Be(nameof(CharacterDefined));
        }

        #endregion
    }
}
