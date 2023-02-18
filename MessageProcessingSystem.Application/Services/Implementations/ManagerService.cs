using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Exceptions.NotExistExceptions;
using MessageProcessingSystem.Application.Extensions;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;
using MessageProcessingSystem.DataAccess.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class ManagerService : IManagerService
{
    private readonly DatabaseContext _dbContext;

    public ManagerService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SubordinateDto> AddSubordinateAsync(string name, string surname, string managerAccountName, CancellationToken cancellationToken)
    {
        Account account = await _dbContext.Accounts.FindAsync(new object[] {managerAccountName}, cancellationToken) ??
                          throw new AccountNotExistException(managerAccountName);
        
        
        var manager = (Manager)account.Employee;
        var subordinate = new Subordinate(Guid.NewGuid(), name, surname, manager);

        _dbContext.Subordinates.Add(subordinate);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return subordinate.AdDto();
    }

    public async Task<IReadOnlyCollection<SubordinateDto>> GetSubordinatesByManagerAsync(string managerAccountName, CancellationToken cancellationToken)
    {
        Account account = await _dbContext.Accounts.FindAsync(new object[] {managerAccountName}, cancellationToken) ??
                          throw new AccountNotExistException(managerAccountName);
        Employee manager = account.Employee;
        return await _dbContext.Subordinates
            .Where(subordinate => subordinate.Boss.Equals(manager))
            .Select(subordinate => subordinate.AdDto())
            .ToListAsync(cancellationToken);
    }

    public async Task<ReportDto> GetReportAsync(DateOnly startOfInterval, DateOnly endOfInterval, string managerAccountName, CancellationToken cancellationToken)
    {
        Account account = await _dbContext.Accounts.FindAsync(new object[] {managerAccountName}, cancellationToken) ??
                          throw new AccountNotExistException(managerAccountName);
        Employee manager = account.Employee;

        DateOnly day = startOfInterval;
        
        int emailMessageCountForInterval = 0;
        int phoneMessageCountForInterval = 0;
        int parsedMessageCountForInterval = 0;
        int allMessagesForInterval = 0;
        
        while (day <= endOfInterval)
        {
            parsedMessageCountForInterval += await GetParsedMessagesCountForDayAsync(day, manager);
            emailMessageCountForInterval += await GetEmailMessageCountForDayAsync(day);
            phoneMessageCountForInterval += await GetPhoneMessageCountForDayAsync(day);
            day = day.AddDays(1);
        }

        allMessagesForInterval += phoneMessageCountForInterval + emailMessageCountForInterval;
        
        var report = new Report(Guid.NewGuid(), manager.Id, startOfInterval, endOfInterval, emailMessageCountForInterval, phoneMessageCountForInterval, parsedMessageCountForInterval, allMessagesForInterval);
        _dbContext.Reports.Add(report);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return report.AsDto();
    }

    public async Task<IReadOnlyCollection<ReportDto>> GetAllManagerReportsAsync(string managerAccountName, CancellationToken cancellationToken)
    {
        Account account = await _dbContext.Accounts.FindAsync(new object[] {managerAccountName}, cancellationToken) ??
                          throw new AccountNotExistException(managerAccountName);
        Employee manager = account.Employee;
        return await _dbContext.Reports.Where(report => report.ManagerId == manager.Id).Select(report => report.AsDto()).ToListAsync(cancellationToken);
    }

    private async Task<int> GetParsedMessagesCountForDayAsync(DateOnly day, Employee manager)
    {
        return await _dbContext.Messages.CountAsync(message => message.Status != "NEW" 
                                             && message.WhoLooked.Boss.Equals(manager) 
                                             && message.ReceiptDate == day
        );
    }

    private async Task<int> GetEmailMessageCountForDayAsync(DateOnly day)
    {
        return await _dbContext.Messages.CountAsync(message => message is EmailMessage && message.ReceiptDate == day);
    }

    private async Task<int> GetPhoneMessageCountForDayAsync(DateOnly day)
    {
        return await _dbContext.Messages.CountAsync(message => message is PhoneMessage && message.ReceiptDate == day);
    }
}