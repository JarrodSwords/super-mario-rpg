using System;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.GameDevelopment.CharacterManagement
{
    public record CreateCharacter(Name Name) : ICommand
    {
        public class Handler : ICommandHandler<CreateCharacter>
        {
            private readonly ICharacterRepository _characterRepository;

            #region Creation

            public Handler(ICharacterRepository characterRepository)
            {
                _characterRepository = characterRepository;
            }

            #endregion

            #region ICommandHandler<CreateCharacter> Implementation

            public IResult Handle(CreateCharacter command)
            {
                var character = Character.Create(command.Name);

                _characterRepository.Create(character);

                return Result.Success(character);
            }

            #endregion
        }
    }

    public record CharacterCreated : Event
    {
        #region Creation

        public CharacterCreated()
        {
            CharacterId = Guid.NewGuid();
        }

        #endregion

        #region Public Interface

        public Guid CharacterId { get; }

        #endregion
    }
}
