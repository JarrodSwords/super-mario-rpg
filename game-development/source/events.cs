using System;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
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
}
