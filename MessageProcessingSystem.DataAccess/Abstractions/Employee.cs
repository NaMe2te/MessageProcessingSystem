namespace MessageProcessingSystem.DataAccess.Abstractions;

public abstract class Employee : IEquatable<Employee>
{
    public Employee(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    protected Employee() { }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }

    public bool Equals(Employee? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && Name == other.Name && Surname == other.Surname;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Surname);
    }
}