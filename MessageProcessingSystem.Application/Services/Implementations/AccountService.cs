using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Extensions;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Enums;
using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly DatabaseContext _dbContext;

    public AccountService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AccountDto> CreateEmployeeAccountAsync(Guid employeeId, string accountName, string accountPassword, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(accountName);
        ArgumentNullException.ThrowIfNull(accountPassword);
        
        Subordinate subordinate = await _dbContext.Subordinates.GetEntityAsync(employeeId, cancellationToken);

        var account = new Account(AccountRole.Subordinate, accountName, accountPassword, subordinate);
        _dbContext.Accounts.Add(account);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return account.AsDto();
    }

    public async Task<AccountDto> CreateManagerAccountAsync(Guid managerId, string accountName, string accountPassword, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(accountName);
        ArgumentNullException.ThrowIfNull(accountPassword);
        
        Manager manager = await _dbContext.Managers.GetEntityAsync(managerId, cancellationToken);
        var account = new Account(AccountRole.Manager, accountName, accountPassword, manager);
        _dbContext.Add(account);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return account.AsDto();
    }
}