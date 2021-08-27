using System;

namespace DevConsole
{
    public class Option
    {
        #region Creation

        public Option(Func<IApplicationState> handler, string name)
        {
            Handler = handler;
            Name = name;
        }

        #endregion

        #region Public Interface

        public Func<IApplicationState> Handler { get; }
        public string Name { get; }

        #endregion
    }
}
