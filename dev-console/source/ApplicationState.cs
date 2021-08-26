using System.Collections.Generic;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Application Application;
        protected Dictionary<char, Option> Options = new();

        #region Creation

        protected ApplicationState(Application application)
        {
            Application = application;
        }

        #endregion

        #region Protected Interface

        protected void DisplayOptions()
        {
            foreach (var (key, value) in Options)
                WriteLine($"{key}. {value.Name}");
        }

        protected void Prompt(string prompt = default)
        {
            Write($"\n{prompt}> ");

            var input = ReadKey().KeyChar;

            if (Options.ContainsKey(input))
                Options[input].Handler.Invoke();
        }

        #endregion

        #region IApplicationState Implementation

        public abstract void Run();

        #endregion
    }
}
