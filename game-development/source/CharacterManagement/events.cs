using System;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public record CharacterRenamed(Guid CharacterId, string Name) : Event;

    public record RenameRejected : Event;
}
