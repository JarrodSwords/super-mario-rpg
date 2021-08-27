using System;
using System.Collections.Generic;
using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly Dictionary<Id, List<IEvent>> _streams = new();
        private readonly List<Action<IEvent>> _subscriptions = new();

        #region ICharacterRepository Implementation

        public ICharacterRepository Create(Character character)
        {
            var events = character.GetPendingEvents().ToList();
            var createdEvent = (CharacterCreated) events.First();

            _streams.Add(createdEvent.CharacterId, events);

            foreach (var @event in events)
            foreach (var subscription in _subscriptions)
                subscription.Invoke(@event);

            return this;
        }

        public Character Find(Id id) =>
            _streams.ContainsKey(id)
                ? Character.From(_streams[id].ToArray())
                : null;

        public ICharacterRepository Subscribe(Action<IEvent> handler)
        {
            _subscriptions.Add(handler);
            return this;
        }

        public ICharacterRepository Update(Character character)
        {
            _streams[character.Id].AddRange(character.GetPendingEvents());
            return this;
        }

        #endregion
    }
}
