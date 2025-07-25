namespace EntityVsValueObject.Model;

public interface IDateTimeProvider
{
    DateTimeOffset NowUtc { get; }
}