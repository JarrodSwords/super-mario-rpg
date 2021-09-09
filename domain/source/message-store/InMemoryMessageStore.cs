using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public class InMemoryMessageStore : IMessageStore
    {
        private readonly Dictionary<StreamId, Stream> _streams = new();

        #region IMessageStore Implementation

        public Stream GetStream(StreamId streamId) => StreamExists(streamId) ? _streams[streamId] : null;

        public IMessageStore Publish(StreamId streamId, IEvent @event)
        {
            if (StreamExists(streamId))
                _streams[streamId].Add(@event);
            else
                _streams[streamId] = new Stream(streamId, @event);

            return this;
        }

        public bool StreamExists(StreamId streamId) => _streams.ContainsKey(streamId);

        #endregion
    }
}
