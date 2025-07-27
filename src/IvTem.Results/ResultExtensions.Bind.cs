namespace IvTem.Results;

public static partial class ResultExtensions
{   
    public static void Bind(
        this Result result,
        Action binder)
    {
        if (result.IsSuccess)
            binder();
    }
    
    public static async Task Bind(
        this Task<Result> resultTask,
        Action binder)
    {
        var result = await resultTask
            .ConfigureAwait(continueOnCapturedContext: false);
        
        if (result.IsSuccess)
            binder();
    }
    
    public static void Bind<TIn>(
        this Result<TIn> result,
        Action<TIn> binder)
    {
        if (result.IsSuccess)
            binder(result.Data!);
    }
    
    public static async Task Bind<T>(
        this Task<Result<T>> resultTask,
        Action<T> binder)
    {
        var result = await resultTask
            .ConfigureAwait(continueOnCapturedContext: false);
        
        if (result.IsSuccess)
            binder(result.Data!);
    }
    
    public static Result<TOut> Bind<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, Result<TOut>> binder)
    {
        return result.IsSuccess
            ? binder(result.Data!)
            : Result<TOut>.Failure(result.Error!);
    }

    public static async Task<Result<TOut>> Bind<TIn, TOut>(
        this Task<Result<TIn>> resultTask,
        Func<TIn, Task<Result<TOut>>> binder)
    {
        var result = await resultTask
            .ConfigureAwait(continueOnCapturedContext: false);
        
        return result.IsSuccess
            ? await binder(result.Data!)
            : Result<TOut>.Failure(result.Error!);
    }
}