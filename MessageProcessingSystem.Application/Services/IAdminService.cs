using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface IAdminService
{
    Task<ManagerDto> AddManagerAsync(string name, string surname, CancellationToken cancellationToken);
    Task<EmailSourceDto> AddEmailSource(string emailGetter, CancellationToken cancellationToken);
    Task<EmailSourceDto> AddPhoneSource(string phoneGetter, CancellationToken cancellationToken);
    Task<AdminDto> AddAdminAsync(string name, string surname, CancellationToken cancellationToken);
}