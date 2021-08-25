using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public interface ICharacterRepository
    {
        ICharacterRepository Create(Character character);
        Character Find(Id id);
    }
}
