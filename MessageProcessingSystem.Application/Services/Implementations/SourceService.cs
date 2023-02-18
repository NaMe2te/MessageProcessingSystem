using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Exceptions.NotExistExceptions.SourceNotFoundExceptions;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models.Messages;
using MessageProcessingSystem.DataAccess.Models.Sources;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class SourceService : ISourceService
{
    private readonly DatabaseContext _dbContext;

    public SourceService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MessageDto> WriteNewEmailMessageAsync(string getterEmail, string text, string senderEmail, CancellationToken cancellationToken)
    {
        var emailMessage = new EmailMessage(Guid.NewGuid(), senderEmail, text);
        Source foundSource = _dbContext.Sources.ToList()
                                 .Find(source =>
                                     source is EmailSource emailSource && emailSource.EmailGetter == getterEmail) ??
                             throw new EmailSourceNotFoundException(getterEmail);
        ((EmailSource)foundSource).Messages.Add(emailMessage);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return emailMessage.AsDto();
    }

    public async Task<MessageDto> WriteNewPhoneMessageAsync(string getterPhone, string text, string senderPhone, CancellationToken cancellationToken)
    {
        var phoneMessage = new PhoneMessage(Guid.NewGuid(), senderPhone, text);
        Source foundSource = _dbContext.Sources.ToList()
                                 .Find(source =>
                                     source is PhoneSource phoneSource && phoneSource.PhoneGetter == getterPhone) ??
                             throw new PhoneSourceNotFoundException(getterPhone);
        ((PhoneSource)foundSource).Messages.Add(phoneMessage);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return phoneMessage.AsDto();
    }
}