using IvTem.DomainDrivenDesign.Abstraction;

namespace EntityVsValueObject.Model;

internal sealed class Person : Entity
{
    public string Name { get; }
    
    public string Surname { get; }
    
    public Age Age { get; }

    public Person(string name, string surname, Age age, Guid? id = null) : base(id)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
    
}