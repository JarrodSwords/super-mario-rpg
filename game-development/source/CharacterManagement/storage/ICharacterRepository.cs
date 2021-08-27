using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public interface ICharacterRepository
    {
        ICharacterRepository Create(Character character);
        Character Find(Id id);
    }
}
