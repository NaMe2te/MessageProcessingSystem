using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Exceptions.NotExistExceptions;
using MessageProcessingSystem.Application.Extensions;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class SubordinatesService : ISubordinatesService
{
    private readonly DatabaseContext _dbContext;

    public SubordinatesService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MessageDto> ViewMessageAsync(Guid messageId, string subordinateAccountName, CancellationToken cancellationToken)
    {
        Account account =
            await _dbContext.Accounts.FindAsync(new object[] {subordinateAccountName}, cancellationToken) ??
            throw new AccountNotExistException(subordinateAccountName);
        var subordinate = (Subordinate)account.Employee;
        
        Message message = await _dbContext.Messages.GetEntityAsync(messageId, cancellationToken);
        message.SetStatusViewed(subordinate);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return message.AsDto();
    }

    public async Task<MessageDto> ReplyToMessageAsync(Guid messageId, string subordinateAccountName, CancellationToken cancellationToken)
    {
        Account account = await _dbContext.Accounts.FindAsync(new object[] {subordinateAccountName}, cancellationToken) ??
                          throw new AccountNotExistException(subordinateAccountName);
        var subordinate = (Subordinate)account.Employee;
        
        Message message = await _dbContext.Messages.GetEntityAsync(messageId, cancellationToken);
        message.SetStatusAnswered(subordinate);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return message.AsDto();
    }

    public async Task<IReadOnlyCollection<MessageDto>> GetNewMessagesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Messages.Where(message => message.Status == "NEW").Select(message => message.AsDto()).ToListAsync();
    }
}