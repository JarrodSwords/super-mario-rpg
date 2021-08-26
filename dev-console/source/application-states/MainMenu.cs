using System;
using static System.Console;

namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu(Application application) : base(application)
        {
            Options['2'] = new Tuple<string, Action>("Quit", Quit);
        }

        #endregion

        #region Public Interface

        public void DisplayView()
        {
            WriteLine("Main Menu\n");

            foreach (var (key, value) in Options)
                WriteLine($"{key}. {value.Item1}");
        }

        public override void Run()
        {
            DisplayView();
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
