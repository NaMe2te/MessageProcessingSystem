using MessageProcessingSystem.DataAccess.Abstractions;

namespace MessageProcessingSystem.DataAccess.Models.Employees;

public class Admin : Employee
{
    public Admin(Guid id, string name, string surname)
        : base(id, name, surname) { }
}