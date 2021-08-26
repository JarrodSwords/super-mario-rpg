using System;

namespace DevConsole
{
    public class CharacterManagementMenu : ApplicationState
    {
        #region Creation

        public CharacterManagementMenu()
        {
            Options['1'] = new(CreateCharacter, "Create Character");
            Options['2'] = new(Cancel, nameof(Cancel));
            Options['3'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public override IApplicationState Run()
        {
            Console.Clear();
            Console.WriteLine("Character Management\n");
            DisplayOptions();
            return Prompt();
        }

        #endregion

        #region Private Interface

        private IApplicationState Cancel() => new MainMenu();

        private IApplicationState CreateCharacter() =>

            //Application.State = new CreateCharacterMenu();
            this;

        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
