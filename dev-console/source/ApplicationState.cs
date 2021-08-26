using System;
using System.Collections.Generic;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Application Application;
        protected Dictionary<char, Tuple<string, Action>> Options = new();

        #region Creation

        protected ApplicationState(Application application)
        {
            Application = application;
        }

        #endregion

        #region Protected Interface

        protected void Prompt(string prompt = default)
        {
            Write($"\n{prompt}> ");

            var input = ReadKey().KeyChar;

            if (Options.ContainsKey(input))
                Options[input].Item2.Invoke();
        }

        #endregion

        #region IApplicationState Implementation

        public abstract void Run();

        #endregion
    }
}
