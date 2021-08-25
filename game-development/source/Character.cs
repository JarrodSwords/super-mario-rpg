using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class Character : Aggregate
    {
        #region Creation

        protected Character(string name) : base(default)
        {
            PendingEvents.Add(new CharacterDefined(name));
        }

        #endregion

        #region Public Interface

        public List<IEvent> PendingEvents { get; } = new();

        public void Rename(string name)
        {
            PendingEvents.Add(new CharacterRenamed(name));
        }

        #endregion

        #region Static Interface

        public static Result Define(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? Result.Failure($"{nameof(name)} cannot be empty")
                : Result.Success(new Character(name));

        #endregion
    }
}
