using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface IAccountService
{
    Task<AccountDto> CreateEmployeeAccountAsync(Guid employeeId, string accountName, string accountPassword,
        CancellationToken cancellationToken);
    Task<AccountDto> CreateManagerAccountAsync(Guid managerId, string accountName, string accountPassword, CancellationToken cancellationToken);
}