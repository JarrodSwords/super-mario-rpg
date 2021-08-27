﻿using System.Text;
using SuperMarioRpg.Domain;
using SuperMarioRpg.GameDevelopment.CharacterManagement;

namespace DevConsole
{
    public class CharacterManagementMenu : ApplicationState
    {
        private readonly ICommandHandler<CreateCharacter> _createCharacterHandler;

        #region Creation

        public CharacterManagementMenu(
            ICommandHandler<CreateCharacter> createCharacterHandler
        ) : base("Character Management")
        {
            _createCharacterHandler = createCharacterHandler;

            Options['1'] = new(CreateCharacter, "Create Character");
            Options['2'] = new(Cancel, nameof(Cancel));
            Options['3'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public MainMenu MainMenu { get; set; }

        #endregion

        #region Protected Interface

        protected override void AppendData(StringBuilder builder)
        {
        }

        #endregion

        #region Private Interface

        private IApplicationState Cancel() => MainMenu;

        private IApplicationState CreateCharacter()
        {
            var name = PromptData("Name");
            var result = _createCharacterHandler.Handle(new CreateCharacter(name));

            return this;
        }

        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}