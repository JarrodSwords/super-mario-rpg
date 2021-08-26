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
    }
}
