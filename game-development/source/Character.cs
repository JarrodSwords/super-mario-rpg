using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class Character : Aggregate
    {
        #region Creation

        public Character(string name) : base(default)
        {
            PendingEvents.Add(new CharacterDefined(name));
        }

        #endregion

        #region Public Interface

        public List<IEvent> PendingEvents { get; } = new();

        #endregion
    }
}
