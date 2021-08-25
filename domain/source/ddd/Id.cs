using System;

namespace SuperMarioRpg.Domain
{
    public class Id : TinyType<Guid>
    {
        #region Creation

        public Id(Guid value = default) : base(value == default ? Guid.NewGuid() : value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Id(Guid source) => new(source);

        #endregion
    }
}
