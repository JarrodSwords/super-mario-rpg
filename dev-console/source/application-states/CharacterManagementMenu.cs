using System;

namespace DevConsole
{
    public class CharacterManagementMenu : ApplicationState
    {
        #region Creation

        public CharacterManagementMenu(Application application) : base(application)
        {
            Options['1'] = new(CreateCharacter, "Create Character");
            Options['2'] = new(Cancel, nameof(Cancel));
            Options['3'] = new(Quit, nameof(Quit));
        }

        #endregion

        #region Public Interface

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine("Main Menu > Character Management\n");
            DisplayOptions();
            Prompt();
        }

        #endregion

        #region Private Interface

        private void Cancel()
        {
            Application.State = new MainMenu(Application);
        }

        private void CreateCharacter()
        {
            //Application.State = new CreateCharacterMenu();
        }

        private void Quit()
        {
            Application.State = Exiting.Singleton;
        }

        #endregion
    }
}
