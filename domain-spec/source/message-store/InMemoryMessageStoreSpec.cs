namespace SuperMarioRpg.Domain.Spec
{
    public class InMemoryMessageStoreSpec : MessageStoreSpec
    {
        #region Creation

        public InMemoryMessageStoreSpec() : base(new InMemoryMessageStore())
        {
        }

        #endregion
    }
}
