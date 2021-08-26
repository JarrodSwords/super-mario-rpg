namespace DevConsole
{
    public class Application
    {
        #region Creation

        public Application()
        {
            State = new MainMenu(this);
        }

        #endregion

        #region Public Interface

        public IApplicationState State { get; set; }

        public void Run()
        {
            while (State != Exiting.Singleton)
                State.Run();
        }

        #endregion
    }
}
