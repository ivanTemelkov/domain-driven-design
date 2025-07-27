namespace IvTem.Results;

public static partial class ResultExtensions
{
    public static void Match(
        this Result result,
        Action onSuccess,
        Action<Error> onFailure)
    {
        if (result.IsSuccess)
            onSuccess();
        else
            onFailure(result.Error!);
    }

    public static async Task Match(
        this Task<Result> resultTask,
        Action onSuccess,
        Action<Error> onFailure)
    {
        var result = await resultTask
            .ConfigureAwait(false);

        if (result.IsSuccess)
            onSuccess();
        else
            onFailure(result.Error!);
    }

    public static TResult Match<T, TResult>(
        this Result<T> result,
        Func<T, TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        return result.IsSuccess
            ? onSuccess(result.Data!)
            : onFailure(result.Error!);
    }

    public static TResult Match<TResult>(
        this Result result,
        Func<TResult> onSuccess,
        Func<Error, TResult> onFailure)
    {
        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Error!);
    }

    public static async Task<TResult> Match<T, TResult>(
        this Task<Result<T>> resultTask,
        Func<T, Task<TResult>> onSuccess,
        Func<Error, Task<TResult>> onFailure)
    {
        var result = await resultTask;
        return result.IsSuccess
            ? await onSuccess(result.Data!)
            : await onFailure(result.Error!);
    }

    public static async Task<TResult> Match<TResult>(
        this Task<Result> resultTask,
        Func<Task<TResult>> onSuccess,
        Func<Error, Task<TResult>> onFailure)
    {
        var result = await resultTask;
        return result.IsSuccess
            ? await onSuccess()
            : await onFailure(result.Error!);
    }
}