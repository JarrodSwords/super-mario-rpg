using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public record CharacterRenamed(string Name) : Event;

    public record RenameRejected : Event;
}
