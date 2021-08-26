using System;

namespace DevConsole
{
    public class Exiting : ApplicationState
    {
        public static Exiting Instance = new();

        #region Creation

        private Exiting() : base(null)
        {
        }

        #endregion

        #region Public Interface

        public override IApplicationState Process(ConsoleKey command) => throw new NotSupportedException();
        public override ConsoleKey Prompt() => throw new NotSupportedException();
        public override IApplicationState WriteView() => throw new NotSupportedException();

        #endregion
    }
}
