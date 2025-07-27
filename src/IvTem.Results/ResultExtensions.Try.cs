namespace IvTem.Results;

public static partial class ResultExtensions
{
    public static Result<T> Try<T>(this Func<T> func)
    {
        try
        {
            return Result<T>.Success(func());
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(new ExceptionError(ex));
        }
    }

    public static Result Try(this Action action)
    {
        try
        {
            action();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new ExceptionError(ex));
        }
    }
    
    public static async Task<Result<T>> Try<T>(this Func<Task<T>> func)
    {
        try
        {
            var result = await func();
            return Result<T>.Success(result);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(new ExceptionError(ex));
        }
    }

    public static async Task<Result> Try(this Func<Task> action)
    {
        try
        {
            await action();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new ExceptionError(ex));
        }
    }
}