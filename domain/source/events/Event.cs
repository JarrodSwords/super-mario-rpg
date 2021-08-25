using System;

namespace SuperMarioRpg.Domain
{
    public abstract record Event : IEvent
    {
        #region Creation

        protected Event()
        {
            Id = Guid.NewGuid();
            Type = GetType().Name;
        }

        #endregion

        #region IEvent Implementation

        public Guid Id { get; }
        public string Type { get; }

        #endregion
    }
}
