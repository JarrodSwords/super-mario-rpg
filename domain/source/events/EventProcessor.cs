using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain
{
    public class EventProcessor : IEventSourced
    {
        private readonly Dictionary<Type, Action<IEvent>> _handlers = new();
        private readonly List<IEvent> _pendingEvents = new();

        #region Public Interface

        public EventProcessor Append(params IEvent[] events)
        {
            foreach (var e in events)
            {
                _handlers[e.GetType()].Invoke(e);
                _pendingEvents.Add(e);
            }

            return this;
        }

        public EventProcessor Register<T>(Action<T> handler = default) where T : IEvent
        {
            handler ??= _ => { };

            _handlers.Add(typeof(T), e => handler((T) e));
            return this;
        }

        public EventProcessor Replay(params IEvent[] events)
        {
            foreach (var e in events)
                _handlers[e.GetType()].Invoke(e);

            return this;
        }

        #endregion

        #region IEventSourced Implementation

        public IReadOnlyList<IEvent> GetPendingEvents() => _pendingEvents.AsReadOnly();

        #endregion
    }
}
