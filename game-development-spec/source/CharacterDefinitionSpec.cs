using FluentAssertions;
using SuperMarioRpg.Domain;
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
            var result = Character.Define("Mario");
            var character = ((Result<Character>) result).Value;
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
            var result = Character.Define(name);

            var character = ((Result<Character>) result).Value;

            _sut.Set(character)
                .Assert<CharacterDefined>(x => x.Name.Should().Be(name))
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
