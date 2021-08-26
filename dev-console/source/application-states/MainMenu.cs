using static System.Console;

namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu(Application application) : base(application)
        {
            Options['2'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public override void Run()
        {
            WriteLine("Main Menu\n");
            DisplayOptions();
            Prompt();
        }

        #endregion

        #region Private Interface

        private void Quit()
        {
            Application.State = Exiting.Singleton;
        }

        #endregion
    }
}
