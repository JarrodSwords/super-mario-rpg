using System.Collections.Generic;
using System.Linq;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly Dictionary<Id, List<IEvent>> _streams = new();

        #region ICharacterRepository Implementation

        public ICharacterRepository Create(Character character)
        {
            var events = character.GetPendingEvents().ToList();
            var createdEvent = (CharacterCreated) events.First();

            _streams.Add(createdEvent.CharacterId, events);
            return this;
        }

        public Character Find(Id id) =>
            _streams.ContainsKey(id)
                ? Character.From(_streams[id].ToArray())
                : null;

        #endregion
    }
}
