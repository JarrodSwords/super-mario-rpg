namespace SuperMarioRpg.Domain
{
    public abstract class Entity
    {
        #region Creation

        protected Entity(Id id)
        {
            Id = id ?? new Id();
        }

        #endregion

        #region Public Interface

        public Id Id { get; }

        #endregion

        #region Equality

        public override bool Equals(object other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return Id == ((Entity) other).Id;
        }

        public override int GetHashCode() => Id == null ? 0 : Id.GetHashCode();

        #endregion
    }
}
