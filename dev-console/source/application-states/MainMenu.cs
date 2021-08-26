namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        #region Creation

        public MainMenu() : base("Main Menu")
        {
            Options['1'] = new(OpenCharacterManagement, "Character Management");
            Options['2'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Private Interface

        private IApplicationState OpenCharacterManagement() => new CharacterManagementMenu();
        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
