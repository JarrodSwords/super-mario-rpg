using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class Character : Aggregate, IEventSourced
    {
        private readonly EventProcessor _eventProcessor = new();
        private Projection _projection = new();

        #region Creation

        public Character(Id id, params IEvent[] events) : this(id)
        {
            _eventProcessor.Replay(events);
        }

        protected Character(Name name) : this()
        {
            _eventProcessor.Append(
                new CharacterDefined(name),
                new CharacterRenamed(name)
            );
        }

        private Character(Id id = default) : base(id)
        {
            _eventProcessor
                .Register<CharacterDefined>(Handler)
                .Register<CharacterRenamed>(Handler);
        }

        #endregion

        #region Public Interface

        public Character Rename(Name name)
        {
            _eventProcessor.Append(new CharacterRenamed(name));
            return this;
        }

        #endregion

        #region Private Interface

        private void Handler(CharacterDefined e)
        {
            _projection = _projection with { name = e.Name };
        }

        private void Handler(CharacterRenamed e)
        {
            _projection = _projection with { name = e.Name };
        }

        #endregion

        #region IEventSourced Implementation

        public IReadOnlyList<IEvent> GetPendingEvents() => _eventProcessor.GetPendingEvents();

        #endregion

        #region Static Interface

        public static Character Create(Name name) => new(name);
        public static Character From(Id id, params IEvent[] events) => new(id, events);

        #endregion

        private record Projection(Name name = default);
    }
}
