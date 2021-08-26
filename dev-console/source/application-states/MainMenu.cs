using static System.Console;

namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu()
        {
            Options['1'] = new(OpenCharacterManagement, "Character Management");
            Options['2'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public override IApplicationState Run()
        {
            Clear();
            WriteLine("Main Menu\n");
            DisplayOptions();
            return Prompt();
        }

        #endregion

        #region Private Interface

        private IApplicationState OpenCharacterManagement() => new CharacterManagementMenu();
        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
