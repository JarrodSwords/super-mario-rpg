using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public interface ICharacterManager
    {
        IResult Create(CreateCharacter command);
        IResult Rename(RenameCharacter command);
    }
}
