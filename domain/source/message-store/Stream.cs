using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public class Stream
    {
        private readonly List<IEvent> _events = new();

        #region Creation

        public Stream(StreamId streamId, params IEvent[] events)
        {
            StreamId = streamId;
            _events.AddRange(events);
        }

        #endregion

        #region Public Interface

        public IReadOnlyList<IEvent> Events => _events.AsReadOnly();
        public StreamId StreamId { get; }

        public Stream Add(params IEvent[] events)
        {
            _events.AddRange(events);
            return this;
        }

        #endregion
    }
}
