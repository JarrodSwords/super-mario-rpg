namespace DevConsole
{
    public class Application
    {
        #region Creation

        public Application()
        {
            ApplicationState = new MainMenu(this);
        }

        #endregion

        #region Public Interface

        public IApplicationState ApplicationState { get; set; }

        public void Run()
        {
            while (ApplicationState != Exiting.Instance)
            {
                ApplicationState.WriteView();
                var input = ApplicationState.Prompt();
                ApplicationState.Process(input);
            }
        }

        #endregion
    }
}
