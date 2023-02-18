using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface ISourceService
{
    Task<MessageDto> WriteNewEmailMessageAsync(string getterEmail, string text, string senderEmail, CancellationToken cancellationToken);
    Task<MessageDto> WriteNewPhoneMessageAsync(string getterPhone, string text, string senderPhone, CancellationToken cancellationToken);
}