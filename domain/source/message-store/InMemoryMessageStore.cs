using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public class InMemoryMessageStore : IMessageStore
    {
        private readonly Dictionary<StreamId, Stream> _streams = new();

        #region IMessageStore Implementation

        public Stream GetStream(StreamId streamId) => StreamExists(streamId) ? _streams[streamId] : null;

        public IMessageStore Publish(StreamId streamId, params IEvent[] events)
        {
            if (StreamExists(streamId))
                _streams[streamId].Add(events);
            else
                _streams[streamId] = new Stream(streamId, events);

            return this;
        }

        public bool StreamExists(StreamId streamId) => _streams.ContainsKey(streamId);

        #endregion
    }
}
