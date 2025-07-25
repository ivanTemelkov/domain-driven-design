using IvTem.DomainDrivenDesign.Abstraction;

namespace EntityVsValueObject.Model;

public sealed class Age : ValueObject
{
    public DateTimeOffset DateOfBirth { get; }

    public Age(DateTimeOffset dateOfBirth)
    {
        DateOfBirth = dateOfBirth;

        // TODO Check for DateTime in the future
    }

    public Age(DateTime dateOfBirth) : this(new DateTimeOffset(dateOfBirth))
    {
    }

    public TimeSpan GetValue(IDateTimeProvider dateTimeProvider)
        => dateTimeProvider.NowUtc.Subtract(DateOfBirth);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DateOfBirth;
    }
}