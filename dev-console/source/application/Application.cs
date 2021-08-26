namespace DevConsole
{
    public class Application
    {
        #region Creation

        public Application()
        {
            State = new MainMenu();
        }

        #endregion

        #region Public Interface

        public IApplicationState State { get; private set; }

        public void Run()
        {
            while (State != Exiting.Singleton)
                State = State.Run();
        }

        #endregion
    }
}
