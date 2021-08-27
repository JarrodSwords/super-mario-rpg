using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public record RenameCharacter(Id Id, Name Name) : ICommand
    {
        public class Handler : ICommandHandler<RenameCharacter>
        {
            private readonly ICharacterRepository _characterRepository;

            #region Creation

            public Handler(ICharacterRepository characterRepository)
            {
                _characterRepository = characterRepository;
            }

            #endregion

            #region ICommandHandler<RenameCharacter> Implementation

            public IResult Handle(RenameCharacter command)
            {
                var character = _characterRepository
                    .Find(command.Id)
                    .Rename(command.Name);

                _characterRepository.Update(character);

                return Result.Success(character.Id);
            }

            #endregion
        }
    }
}
