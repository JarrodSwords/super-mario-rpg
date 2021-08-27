namespace DevConsole
{
    public class MainMenu : ApplicationState
    {
        private readonly CharacterManagementMenu _characterManagementMenu;

        #region Creation

        public MainMenu(CharacterManagementMenu characterManagementMenu) : base("Main Menu")
        {
            _characterManagementMenu = characterManagementMenu;
            Options['1'] = new(OpenCharacterManagement, "Character Management");
            Options['2'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Private Interface

        private IApplicationState OpenCharacterManagement() => _characterManagementMenu;
        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
