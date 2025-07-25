using IvTem.DomainDrivenDesign.Abstraction;

namespace EntityVsValueObject.Model;

internal sealed class Person : Entity
{
    public FullName FullName { get; }

    public Age Age { get; }

    public Person(string name, string surname, Age age, Guid? id = null) : this(name, middleName: null, surname, age,
        id)
    {
    }

    public Person(string name, string? middleName, string surname, Age age, Guid? id = null) : base(id)
    {
        FullName = middleName is null
            ? new FullName(name, surname)
            : new FullName(name, middleName, surname);

        Age = age;
    }
}