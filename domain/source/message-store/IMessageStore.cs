namespace SuperMarioRpg.Domain
{
    public interface IMessageStore
    {
        Stream GetStream(StreamId streamId);
        IMessageStore Publish(StreamId streamId, params IEvent[] events);
        bool StreamExists(StreamId streamId);
    }
}
