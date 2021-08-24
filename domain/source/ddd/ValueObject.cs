using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRpg.Domain
{
    public abstract class ValueObject
    {
        #region Equality

        public override bool Equals(object other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return GetEqualityComponents().SequenceEqual(
                ((ValueObject) other).GetEqualityComponents()
            );
        }

        public abstract IEnumerable<object> GetEqualityComponents();

        public override int GetHashCode() =>
            GetEqualityComponents().Aggregate(
                1,
                (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                }
            );

        #endregion
    }
}
