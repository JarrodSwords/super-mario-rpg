using System.Collections.Generic;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Dictionary<char, Option> Options = new();

        #region Creation

        protected ApplicationState(string title)
        {
            Title = title;
        }

        #endregion

        #region Public Interface

        public string Title { get; }

        #endregion

        #region Protected Interface

        protected virtual void DisplayData()
        {
        }

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

        public IApplicationState Run()
        {
            Clear();
            WriteLine(Title);
            DisplayData();
            DisplayOptions();
            return Prompt();
        }

        #endregion
    }
}
