using FluentAssertions;
using SuperMarioRpg.GameDevelopment.CharacterManagement;
using Xunit;

namespace SuperMarioRpg.GameDevelopment.Spec.CharacterManagement
{
    public class CharacterSpec
    {
        #region Core

        private const string Mario = "Mario";
        private readonly Character _character;
        private readonly SystemUnderTest _sut;

        public CharacterSpec()
        {
            var character = Character.Create(Mario);
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
        public void WhenCreating_CharacterInitialized(string name)
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

        [Fact]
        public void WhenRenaming_WithSameName_RenameRejected()
        {
            _character.Rename(Mario);

            _sut.Assert<RenameRejected>();
        }

        #endregion
    }
}
