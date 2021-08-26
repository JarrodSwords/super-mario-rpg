using System;

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

        #region IApplicationState Implementation

        public abstract IApplicationState Process(ConsoleKey key);
        public abstract ConsoleKey Prompt();
        public abstract IApplicationState WriteView();

        #endregion
    }
}
