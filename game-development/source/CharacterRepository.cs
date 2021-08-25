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
            _streams.Add(character.Id, character.GetPendingEvents().ToList());
            return this;
        }

        public Character Find(Id id) =>
            _streams.ContainsKey(id)
                ? Character.From(id, _streams[id].ToArray())
                : null;

        #endregion
    }
}
