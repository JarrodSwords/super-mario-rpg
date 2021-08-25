using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public class Character : IEventSourced
    {
        private readonly EventProcessor _eventProcessor = new();
        private Projection _projection = new();

        #region Creation

        private Character()
        {
            _eventProcessor
                .Register<CharacterCreated>(Handler)
                .Register<CharacterRenamed>(Handler)
                .Register<RenameRejected>();
        }

        private Character(Name name) : this()
        {
            _eventProcessor.Append(
                new CharacterCreated(),
                new CharacterRenamed(name)
            );
        }

        private Character(params IEvent[] events) : this()
        {
            _eventProcessor.Replay(events);
        }

        #endregion

        #region Public Interface

        public Id Id => _projection.Id ?? ((CharacterCreated) _eventProcessor.GetPendingEvents()[0]).CharacterId;

        public Character Rename(Name name)
        {
            _eventProcessor.Append(
                name == _projection.Name
                    ? new RenameRejected()
                    : new CharacterRenamed(name)
            );

            return this;
        }

        #endregion

        #region Private Interface

        private void Handler(CharacterCreated e)
        {
            _projection = _projection with { Id = e.CharacterId };
        }

        private void Handler(CharacterRenamed e)
        {
            _projection = _projection with { Name = e.Name };
        }

        #endregion

        #region IEventSourced Implementation

        public IReadOnlyList<IEvent> GetPendingEvents() => _eventProcessor.GetPendingEvents();

        #endregion

        #region Static Interface

        public static Character Create(Name name) => new(name);
        public static Character From(params IEvent[] events) => new(events);

        #endregion

        private record Projection(Id Id = default, Name Name = default);
    }
}
