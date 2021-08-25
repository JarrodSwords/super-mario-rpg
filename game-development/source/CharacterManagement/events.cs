using System;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public record CharacterCreated : Event
    {
        #region Creation

        public CharacterCreated()
        {
            CharacterId = Guid.NewGuid();
        }

        #endregion

        #region Public Interface

        public Guid CharacterId { get; }

        #endregion
    }

    public record CharacterRenamed(string Name) : Event;

    public record RenameRejected : Event;
}
