using MessageProcessingSystem.DataAccess.Abstractions;

namespace MessageProcessingSystem.DataAccess.Models.Employees;

public class Manager : Employee
{
    public Manager(Guid id, string name, string surname)
        : base(id, name, surname)
    {
        Subordinates = new List<Subordinate>();
        Reports = new List<Report>();
    }

    protected Manager() { }

    public virtual ICollection<Report> Reports { get; init; }
    public virtual ICollection<Subordinate> Subordinates { get; init; }
}