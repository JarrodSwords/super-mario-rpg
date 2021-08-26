using System;

namespace DevConsole
{
    public class Option
    {
        #region Creation

        public Option(Action handler, string name)
        {
            Handler = handler;
            Name = name;
        }

        #endregion

        #region Public Interface

        public Action Handler { get; }
        public string Name { get; }

        #endregion
    }
}
