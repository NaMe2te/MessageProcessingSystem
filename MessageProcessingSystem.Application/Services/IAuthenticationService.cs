using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface IAuthenticationService
{
    Task<AccountDto> LoginAsync(string name, string password, CancellationToken cancellationToken);
    Task<AccountDto> RegisterAsync(string accountName, string accountPassword, Guid employeeId, CancellationToken cancellationToken);
}