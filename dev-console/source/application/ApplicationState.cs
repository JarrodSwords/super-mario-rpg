using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DevConsole
{
    public abstract class ApplicationState : IApplicationState
    {
        protected Dictionary<int, Option> Options = new();

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

        protected abstract void AppendData(StringBuilder builder);

        protected void AppendOptions(StringBuilder builder)
        {
            builder.AppendLine();

            foreach (var (key, value) in Options)
                builder.Append($"\n{key}. {value.Name}");
        }

        protected virtual void AppendTitle(StringBuilder builder) => builder.Append($"{Title}");

        protected string PromptData(string prompt = default)
        {
            Write($"\n\n{prompt}> ");

            return ReadLine();
        }

        protected IApplicationState PromptSelection(string prompt = default)
        {
            Write($"\n\n{prompt}> ");

            int.TryParse(ReadKey().KeyChar.ToString(), out var input);

            if (input == default)
                return this;

            return Options.ContainsKey(input)
                ? Options[input].Handler.Invoke()
                : this;
        }

        #endregion

        #region IApplicationState Implementation

        public IApplicationState Run()
        {
            var sb = new StringBuilder();

            AppendTitle(sb);
            AppendData(sb);
            AppendOptions(sb);

            Clear();
            Write(sb.ToString());

            return PromptSelection();
        }

        #endregion
    }
}
