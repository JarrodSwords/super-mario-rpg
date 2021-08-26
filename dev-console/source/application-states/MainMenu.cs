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

        public override IApplicationState Process(ConsoleKey command)
        {
            if (command == ConsoleKey.D2)
                Application.ApplicationState = Exiting.Instance;

            return this;
        }

        public override ConsoleKey Prompt()
        {
            Console.Write(":> ");
            return Console.ReadKey().Key;
        }

        public override IApplicationState WriteView()
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
