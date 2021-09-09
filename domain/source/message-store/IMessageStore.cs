namespace SuperMarioRpg.Domain
{
    public interface IMessageStore
    {
        void Publish(StreamId streamId, IEvent @event);
        bool StreamExists(StreamId streamId);
    }
}
