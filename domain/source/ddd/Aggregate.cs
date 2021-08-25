namespace SuperMarioRpg.Domain
{
    public abstract class Aggregate : Entity
    {
        #region Creation

        protected Aggregate(Id id) : base(id)
        {
        }

        #endregion
    }
}
