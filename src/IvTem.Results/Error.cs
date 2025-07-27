namespace IvTem.Results;

public class Error
{
    public static readonly string UndefinedCode = "##undefined##";
    public string Code { get; }
    public string Message { get; }

    public Error(string message) : this(UndefinedCode, message)
    {
        Message = message;
    }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString() => $"{Code}: {Message}";
}