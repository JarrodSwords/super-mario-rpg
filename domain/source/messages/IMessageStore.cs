using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public interface IMessageStore
    {
        void Publish(StreamId streamId, IEvent @event);
        bool StreamExists(StreamId streamId);
    }

    public class InMemoryMessageStore : IMessageStore
    {
        private readonly Dictionary<StreamId, List<IEvent>> _streams = new();

        #region IMessageStore Implementation

        public void Publish(StreamId streamId, IEvent @event)
        {
            _streams[streamId] = new List<IEvent> { @event };
        }

        public bool StreamExists(StreamId streamId) => _streams.ContainsKey(streamId);

        #endregion
    }
}
