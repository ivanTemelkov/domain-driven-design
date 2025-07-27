namespace IvTem.Results;

public static partial class ResultExtensions
{   
    public static Result<TOut> Map<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> mapper)
    {
        return result.IsSuccess
            ? Result<TOut>.Success(mapper(result.Data!))
            : Result<TOut>.Failure(result.Error!);
    }
    
    public static async Task<Result<TOut>> Map<TIn, TOut>(
        this Task<Result<TIn>> resultTask,
        Func<TIn, Task<TOut>> mapper)
    {
        var result = await resultTask;

        if (result.IsSuccess == false)
            return Result<TOut>.Failure(result.Error!);

        var mapped = await mapper(result.Data!);
        
        return Result<TOut>.Success(mapped);
    }
}