using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public class CharacterManager : ICharacterManager
    {
        private readonly ICommandHandler<CreateCharacter> _createCharacterHandler;
        private readonly ICommandHandler<RenameCharacter> _renameCharacterHandler;

        #region Creation

        public CharacterManager(
            ICommandHandler<CreateCharacter> createCharacterHandler,
            ICommandHandler<RenameCharacter> renameCharacterHandler
        )
        {
            _createCharacterHandler = createCharacterHandler;
            _renameCharacterHandler = renameCharacterHandler;
        }

        #endregion

        #region ICharacterManager Implementation

        public IResult Create(CreateCharacter command) => _createCharacterHandler.Handle(command);
        public IResult Rename(RenameCharacter command) => _renameCharacterHandler.Handle(command);

        #endregion
    }
}
