using MessageProcessingSystem.DataAccess.Abstractions;

namespace MessageProcessingSystem.DataAccess.Models.Employees;

public class Subordinate : Employee
{
    public Subordinate(Guid id, string name, string surname, Manager boss)
        : base(id, name, surname)
    {
        Messages = new List<Message>();
        Boss = boss;
    }

    protected Subordinate() { }

    public virtual Manager Boss { get; init; }
    public virtual ICollection<Message> Messages { get; init; }
}