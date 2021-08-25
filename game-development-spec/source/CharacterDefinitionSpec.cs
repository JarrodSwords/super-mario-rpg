using FluentAssertions;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec
{
    public class CharacterDefinitionSpec
    {
        #region Core

        private readonly Character _character;
        private readonly SystemUnderTest _sut;

        public CharacterDefinitionSpec()
        {
            var character = Character.Create("Mario");
            _character = new CharacterRepository()
                .Create(character)
                .Find(character.Id);

            _sut = new SystemUnderTest().Set(_character);
        }

        #endregion

        #region Test Methods

        [Theory]
        [InlineData("Mario")]
        [InlineData("Chancellor")]
        public void WhenDefiningCharacter_CharacterInitialized(string name)
        {
            var character = Character.Create(name);

            _sut.Set(character)
                .Assert<CharacterCreated>(x => x.CharacterId.Should().NotBeEmpty())
                .Assert<CharacterRenamed>(x => x.Name.Should().Be(name));
        }

        [Theory]
        [InlineData("Mallow")]
        [InlineData("Geno")]
        public void WhenRenaming_CharacterRenamed(string name)
        {
            _character.Rename(name);

            _sut.Assert<CharacterRenamed>(x => x.Name.Should().Be(name));
        }

        #endregion
    }
}
