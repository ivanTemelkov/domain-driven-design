namespace IvTem.Results;

public class ExceptionError : Error
{
    public Exception Exception { get; }

    public ExceptionError(Exception ex, string? errorCode = null)
        : base(errorCode ?? UndefinedCode, ex.Message)
    {
        Exception = ex;
    }
}