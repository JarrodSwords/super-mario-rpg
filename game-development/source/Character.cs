using System;
using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class Character : Aggregate, IEventSourced
    {
        private readonly EventSourced _eventSourced = new();
        private Projection _projection;

        #region Creation

        public Character(Id id, params IEvent[] events) : this(id)
        {
            _eventSourced.Replay(events);
        }

        protected Character(Name name) : this()
        {
            _eventSourced.Append(new CharacterDefined(name));
        }

        private Character(Id id = default) : base(id)
        {
            _projection = new Projection();

            _eventSourced
                .Register<CharacterDefined>(Handler)
                .Register<CharacterRenamed>(Handler);
        }

        #endregion

        #region Public Interface

        public Character Rename(Name name)
        {
            _eventSourced.Append(new CharacterRenamed(name));
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

        public IReadOnlyList<IEvent> GetPendingEvents() => _eventSourced.GetPendingEvents();

        #endregion

        #region Static Interface

        public static Result Define(Name name)
        {
            try
            {
                return Result.Success(new Character(name));
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }
        }

        #endregion

        private record Projection(Name name = default);
    }
}
