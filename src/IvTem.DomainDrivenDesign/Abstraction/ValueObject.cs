namespace IvTem.DomainDrivenDesign.Abstraction;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
	    
        if (ReferenceEquals(this, obj))
            return true;
	    
        if (obj.GetType() != GetType())
            return false;
	    
        return Equals((ValueObject)obj);
    }
    
    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;
	    
        if (ReferenceEquals(this, other))
            return true;

        return other.GetEqualityComponents()
            .SequenceEqual(GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }
}