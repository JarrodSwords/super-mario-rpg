namespace SuperMarioRpg.Domain
{
    public interface IResult
    {
        bool WasFailure();
        bool WasSuccessful();
    }
}
