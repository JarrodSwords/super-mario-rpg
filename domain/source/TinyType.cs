using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public abstract class TinyType<T> : ValueObject
    {
        #region Creation

        protected TinyType(T value)
        {
            Value = value;
        }

        #endregion

        #region Public Interface

        public T Value { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}
