namespace SuperMarioRpg.Domain
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        IResult Handle(T command);
    }
}
