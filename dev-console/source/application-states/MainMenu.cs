using System.Text;

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

        #region Public Interface

        public CharacterManagementMenu CharacterManagementMenu { get; set; }

        #endregion

        #region Protected Interface

        protected override void AppendData(StringBuilder builder)
        {
        }

        #endregion

        #region Private Interface

        private IApplicationState OpenCharacterManagement() => CharacterManagementMenu;
        private IApplicationState Quit() => Exiting.Singleton;

        #endregion
    }
}
