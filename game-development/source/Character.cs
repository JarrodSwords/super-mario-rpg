using System;
using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class Character : Aggregate
    {
        #region Creation

        protected Character(Name name) : base(default)
        {
            PendingEvents.Add(new CharacterDefined(name));
        }

        #endregion

        #region Public Interface

        public List<IEvent> PendingEvents { get; } = new();

        public Character Rename(Name name)
        {
            PendingEvents.Add(new CharacterRenamed(name));
            return this;
        }

        #endregion

        #region Static Interface

        public static Result Define(Name name)
        {
            try
            {
                return Result.Success(new Character(name));
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }
        }

        #endregion
    }
}
