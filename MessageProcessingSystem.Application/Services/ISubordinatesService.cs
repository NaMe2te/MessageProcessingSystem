using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface ISubordinatesService
{
    Task<MessageDto> ViewMessageAsync(Guid messageId, string subordinateAccountName, CancellationToken cancellationToken);
    Task<MessageDto> ReplyToMessageAsync(Guid messageId, string subordinateAccountName, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<MessageDto>> GetNewMessagesAsync(CancellationToken cancellationToken);
}