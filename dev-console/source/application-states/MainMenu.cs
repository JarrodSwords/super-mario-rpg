using static System.Console;

namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu(Application application) : base(application)
        {
            Options['1'] = new(OpenCharacterManagement, "Character Management");
            Options['2'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public override void Run()
        {
            Clear();
            WriteLine("Main Menu\n");
            DisplayOptions();
            Prompt();
        }

        #endregion

        #region Private Interface

        private void OpenCharacterManagement()
        {
            Application.State = new CharacterManagementMenu(Application);
        }

        private void Quit()
        {
            Application.State = Exiting.Singleton;
        }

        #endregion
    }
}
