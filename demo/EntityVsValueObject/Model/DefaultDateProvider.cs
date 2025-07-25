namespace EntityVsValueObject.Model;

public sealed class DefaultDateProvider : IDateTimeProvider
{
    public static DefaultDateProvider Instance { get; } = new DefaultDateProvider();
    public DateTimeOffset NowUtc => DateTimeOffset.UtcNow;

    private DefaultDateProvider()
    {
        
    }
    
}

public sealed class FixedDateProvider : IDateTimeProvider
{
    public DateTimeOffset NowUtc { get; }
    
    public FixedDateProvider(DateTimeOffset fixedUtcNow)
    {
        NowUtc = fixedUtcNow;
    }
}