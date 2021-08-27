using System;
using System.Text;

namespace DevConsole
{
    public class Exiting : ApplicationState
    {
        public static Exiting Singleton = new();

        #region Creation

        public Exiting() : base(default)
        {
        }

        #endregion

        #region Protected Interface

        protected override void AppendData(StringBuilder builder)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
