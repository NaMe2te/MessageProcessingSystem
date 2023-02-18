using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Enums;

namespace MessageProcessingSystem.DataAccess.Models;

public class Account
{
    public Account(AccountRole accountRole, string name, string password, Employee employee)
    {
        Name = name;
        AccountRole = accountRole;
        Password = password;
        Employee = employee;
    }

    protected Account() { }

    public string Name { get; init; }
    public string Password { get; init; }
    public AccountRole AccountRole { get; init; }
    public virtual Employee Employee { get; init; }
}