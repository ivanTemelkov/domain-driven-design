namespace IvTem.Results;

public class Result
{
    private static readonly Result SuccessInstance = new(isSuccess: true, null);
    public bool IsSuccess { get; }
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => SuccessInstance;

    public static Result Failure(Error error)
        => new Result(false, error);
}

public sealed class Result<T> : Result
{
    public T? Data { get; }

    private Result(bool isSuccess, T? data, Error? error)
        : base(isSuccess, error)
    {
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        
        return new Result<T>(true, data, error: null);
    }

    public new static Result<T> Failure(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);

        return new Result<T>(false, data: default, error);
    }
}