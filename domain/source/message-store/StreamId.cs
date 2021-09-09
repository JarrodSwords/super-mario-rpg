using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public class StreamId : ValueObject
    {
        #region Creation

        public StreamId(Id entityId, bool isCommand, Name name)
        {
            EntityId = entityId;
            IsCommand = isCommand;
            Name = name;
        }

        #endregion

        #region Public Interface

        public Id EntityId { get; }
        public bool IsCommand { get; }
        public Name Name { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return EntityId;
            yield return IsCommand;
            yield return Name;
        }

        #endregion
    }
}
