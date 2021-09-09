namespace SuperMarioRpg.Domain
{
    public interface IMessageStore
    {
        Stream GetStream(StreamId streamId);
        IMessageStore Publish(StreamId streamId, IEvent @event);
        bool StreamExists(StreamId streamId);
    }
}
