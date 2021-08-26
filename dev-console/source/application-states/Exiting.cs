using System;

namespace DevConsole
{
    public class Exiting : ApplicationState
    {
        public static Exiting Singleton = new();

        #region Public Interface

        public override IApplicationState Run() => throw new NotSupportedException();

        #endregion
    }
}
