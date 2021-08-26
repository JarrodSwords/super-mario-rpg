using System;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Application Application;

        #region Creation

        protected ApplicationState(Application application)
        {
            Application = application;
        }

        #endregion

        #region Protected Interface

        protected ConsoleKey Prompt(string prompt = default)
        {
            Write($"{prompt}> ");
            return ReadKey().Key;
        }

        #endregion

        #region IApplicationState Implementation

        public abstract void Run();

        #endregion
    }
}
