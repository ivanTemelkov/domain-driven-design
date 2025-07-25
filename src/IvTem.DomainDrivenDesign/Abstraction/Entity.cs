namespace IvTem.DomainDrivenDesign.Abstraction;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; }

    protected Entity(Guid? id = null)
    {
	    // TODO If > .NET 9 use Guid.CreateVersion7(); 
	    Id = id ?? Guid.NewGuid();
    }

    public bool Equals(Entity? other)
    {
	    if (other is null)
		    return false;
	    
	    if (ReferenceEquals(this, other))
		    return true;
	    
	    return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
	    if (obj is null)
		    return false;
	    
	    if (ReferenceEquals(this, obj))
		    return true;
	    
	    if (obj.GetType() != GetType())
		    return false;
	    
	    return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
	    return Id.GetHashCode();
    }
}
