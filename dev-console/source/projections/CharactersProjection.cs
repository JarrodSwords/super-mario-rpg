using System;
using System.Collections.Generic;
using System.Linq;
using SuperMarioRpg.Domain;
using SuperMarioRpg.GameDevelopment.CharacterManagement;

namespace DevConsole
{
    public class CharactersProjection
    {
        private readonly Dictionary<Guid, Character> _characters = new();

        #region Creation

        public CharactersProjection(ICharacterRepository characterRepository)
        {
            characterRepository.Subscribe(Handle);
        }

        #endregion

        #region Public Interface

        public IReadOnlyCollection<Character> Characters =>
            _characters
                .Select(x => x.Value)
                .ToList();

        public bool IsEmpty => !_characters.Any();

        #endregion

        #region Private Interface

        private void CharacterCreated(CharacterCreated e)
        {
            _characters.Add(e.CharacterId, new Character(e.CharacterId));
        }

        private void CharacterRenamed(CharacterRenamed e)
        {
            _characters[e.CharacterId] = _characters[e.CharacterId] with { Name = e.Name };
        }

        private void Handle(IEvent e)
        {
            var type = e.GetType();

            if (type == typeof(CharacterCreated))
                CharacterCreated(e as CharacterCreated);
            else if (type == typeof(CharacterRenamed))
                CharacterRenamed(e as CharacterRenamed);
        }

        #endregion
    }

    public record Character(Guid Id, string Name = default);
}
