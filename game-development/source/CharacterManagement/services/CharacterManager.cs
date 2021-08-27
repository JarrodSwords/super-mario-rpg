using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public class CharacterManager : ICharacterManager
    {
        private readonly ICommandHandler<CreateCharacter> _createCharacterHandler;

        #region Creation

        public CharacterManager(ICommandHandler<CreateCharacter> createCharacterHandler)
        {
            _createCharacterHandler = createCharacterHandler;
        }

        #endregion

        #region ICharacterManager Implementation

        public IResult Create(CreateCharacter command) => _createCharacterHandler.Handle(command);

        #endregion
    }
}
