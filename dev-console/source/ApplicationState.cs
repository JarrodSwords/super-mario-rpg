using System.Collections.Generic;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Application Application;
        protected Dictionary<char, Option> Options = new();

        #region Protected Interface

        protected void DisplayOptions()
        {
            foreach (var (key, value) in Options)
                WriteLine($"{key}. {value.Name}");
        }

        protected IApplicationState Prompt(string prompt = default)
        {
            Write($"\n{prompt}> ");

            var input = ReadKey().KeyChar;

            return Options.ContainsKey(input)
                ? Options[input].Handler.Invoke()
                : this;
        }

        #endregion

        #region IApplicationState Implementation

        public abstract IApplicationState Run();

        #endregion
    }
}
