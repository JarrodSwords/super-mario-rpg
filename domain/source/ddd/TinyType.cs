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

        public static bool operator ==(TinyType<T> left, TinyType<T> right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(TinyType<T> left, TinyType<T> right) => !(left == right);

        #endregion
    }
}
