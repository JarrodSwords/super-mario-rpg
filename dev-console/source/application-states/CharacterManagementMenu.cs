using System.Collections.Generic;
using System.Text;
using SuperMarioRpg.GameDevelopment.CharacterManagement;

namespace DevConsole
{
    public class CharacterManagementMenu : ApplicationState
    {
        private readonly ICharacterManager _characterManager;
        private readonly CharactersProjection _charactersProjection;

        #region Creation

        public CharacterManagementMenu(
            ICharacterManager characterManager,
            CharactersProjection charactersProjection
        ) : base("Character Management")
        {
            _characterManager = characterManager;
            _charactersProjection = charactersProjection;

            var options = new List<Option>
            {
                new(CreateCharacter, "Create Character"),
                new(Cancel, nameof(Cancel)),
                new(Quit, nameof(Quit))
            };

            for (var i = 1; i <= options.Count; i++)
                Options.Add(i, options[i - 1]);
        }

        #endregion

        #region Public Interface

        public MainMenu MainMenu { get; set; }

        #endregion

        #region Protected Interface

        protected override void AppendData(StringBuilder builder)
        {
            if (_charactersProjection.IsEmpty)
                return;

            builder.AppendLine();

            foreach (var character in _charactersProjection.Characters)
                builder.Append($"\n  - {character.Name}");
        }

        #endregion

        #region Private Interface

        private IApplicationState Cancel() => MainMenu;

        private IApplicationState CreateCharacter()
        {
            var name = PromptData("Name");
            var result = _characterManager.Create(new CreateCharacter(name));

            return this;
        }

        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
