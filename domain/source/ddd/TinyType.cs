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

        #region Static Interface

        public static implicit operator T(TinyType<T> source) => source is null ? default : source.Value;

        #endregion
    }
}
