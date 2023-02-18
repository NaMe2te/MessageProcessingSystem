using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Exceptions;
using MessageProcessingSystem.Application.Exceptions.AlreadyExistExceptions;
using MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Enums;
using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly DatabaseContext _dbContext;

    public AuthenticationService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<AccountDto> LoginAsync(string name, string password, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(password);

        Account accountDto = await _dbContext.Accounts.FindAsync(new object[] {name}, cancellationToken) ??
                             throw new InvalidLoginOrPasswordException();

        return accountDto.Password == password ? accountDto.AsDto() : throw new InvalidLoginOrPasswordException();
    }

    public async Task<AccountDto> RegisterAsync(string accountName, string accountPassword, Guid employeeId, CancellationToken cancellationToken)
    {
        Account? account = await _dbContext.Accounts.FindAsync(new object[] {accountName}, cancellationToken);
        if (account is not null)
            throw new AccountAlreadyExistException(accountName);

        var subordinatesList = _dbContext.Subordinates.ToList();
        var managersList = _dbContext.Managers.ToList();
        var adminsList = _dbContext.Admins.ToList();
        var employees = adminsList.Concat(subordinatesList.Concat<Employee>(managersList)).ToList();

        Employee employee = employees.Find(e => e.Id == employeeId) ?? throw new EmployeeNotFoundException(employeeId);

        AccountRole accountRole = employee switch
        {
            Manager => AccountRole.Manager,
            Admin => AccountRole.Admin,
            _ => AccountRole.Subordinate
        };

        var newAccount = new Account(accountRole, accountName, accountPassword, employee);
        _dbContext.Accounts.Add(newAccount);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newAccount.AsDto();
        
    }
}