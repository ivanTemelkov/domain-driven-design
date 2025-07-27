using System.Diagnostics.CodeAnalysis;

namespace IvTem.Results;

public static partial class ResultExtensions
{
    public static bool IsSuccess(
        this Result result,
        [NotNullWhen(returnValue: false)] out Error? error)
    {
        if (result.IsSuccess)
        {
            error = null;
            return true;
        }

        error = result.Error!;
        return false;
    }
    
    public static bool IsSuccess<T>(
        this Result<T> result,
        [NotNullWhen(returnValue: true)] out T? data,
        [NotNullWhen(returnValue: false)] out Error? error)
    {
        if (result.IsSuccess)
        {
            data = result.Data!;
            error = null;
            return true;
        }

        data = default;
        error = result.Error!;
        return false;
    }
    
    public static bool IsSuccess<T>(
        this Result<T> result,
        [NotNullWhen(returnValue: true)] out T? data)
    {
        data = result.Data;
        return data is not null;
    }
    
    public static Result<T> AsFailure<T>(this Error error)
    {
        return Result<T>.Failure(error);
    }
}