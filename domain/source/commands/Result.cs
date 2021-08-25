namespace SuperMarioRpg.Domain
{
    public class Result : IResult
    {
        private readonly Status _status;

        #region Creation

        protected Result(Status status, string message = default)
        {
            _status = status;
            Message = message;
        }

        #endregion

        #region Public Interface

        public string Message { get; }

        #endregion

        #region IResult Implementation

        public bool WasFailure() => _status == Status.Failed;
        public bool WasSuccessful() => _status == Status.Succeeded;

        #endregion

        #region Static Interface

        public static Result Failure(string message) => new(Status.Failed, message);
        public static Result<T> Success<T>(T value) => new(value);

        #endregion

        protected enum Status
        {
            Failed,
            Succeeded
        }
    }

    public class Result<T> : Result
    {
        #region Creation

        protected internal Result(T value) : base(Status.Succeeded)
        {
            Value = value;
        }

        #endregion

        #region Public Interface

        public T Value { get; set; }

        #endregion
    }
}
