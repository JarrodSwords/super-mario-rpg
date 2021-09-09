using System;

namespace SuperMarioRpg.Domain
{
    public class Name : TinyType<string>
    {
        #region Creation

        protected Name(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();
        }

        #endregion

        #region Static Interface

        public static implicit operator Name(string source) => new(source);

        #endregion
    }
}
