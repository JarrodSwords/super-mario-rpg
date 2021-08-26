using System;

namespace DevConsole
{
    public class Exiting : ApplicationState
    {
        public static Exiting Singleton = new();

        #region Creation

        private Exiting() : base(default)
        {
        }

        #endregion

        #region Public Interface

        public override void Run()
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
