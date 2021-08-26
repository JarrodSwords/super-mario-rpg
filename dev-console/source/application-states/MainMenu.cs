using System;

namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu(Application application) : base(application)
        {
        }

        #endregion

        #region Public Interface

        public IApplicationState Process(ConsoleKey command)
        {
            if (command == ConsoleKey.D2)
                Application.ApplicationState = Exiting.Singleton;

            return this;
        }

        public override void Run()
        {
        }

        public IApplicationState WriteView()
        {
            Console.WriteLine(
                @"Main Menu

1. Character Management
2. Quit
"
            );
            return this;
        }

        #endregion
    }
}
