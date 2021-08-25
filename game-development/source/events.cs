using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public record CharacterDefined(string Name) : Event;

    public record CharacterRenamed(string Name) : Event;
}
