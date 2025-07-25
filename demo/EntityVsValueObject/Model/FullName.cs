using IvTem.DomainDrivenDesign.Abstraction;

namespace EntityVsValueObject.Model;

public class FullName : ValueObject
{
    public string Name { get; }
    public string? MiddleName { get; }
    public string Surname { get; }

    public string Value { get; }
    
    public FullName(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(surname));
        
        Name = name;
        Surname = surname;

        Value = $"{Name} {Surname}";
    }
    
    public FullName(string name, string middleName, string surname)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        if (string.IsNullOrWhiteSpace(middleName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(middleName));
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(surname));
        
        Name = name;
        MiddleName = middleName;
        Surname = surname;
        
        Value = $"{Name} {MiddleName[0]}. {Surname}";
    }


    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Surname;
        yield return MiddleName;
    }
}