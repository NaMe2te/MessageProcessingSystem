using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Mapping;
using MessageProcessingSystem.DataAccess;
using MessageProcessingSystem.DataAccess.Models.Employees;
using MessageProcessingSystem.DataAccess.Models.Sources;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.Application.Services.Implementations;

public class AdminService : IAdminService
{
    private readonly DatabaseContext _dbContext;

    public AdminService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ManagerDto> AddManagerAsync(string name, string surname, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(surname);
        
        var manager = new Manager(Guid.NewGuid(), name, surname);
        _dbContext.Managers.Add(manager);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return manager.AsDto();
    }

    public async Task<EmailSourceDto> AddEmailSource(string emailGetter, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(emailGetter);
        
        var emailSource = new EmailSource(Guid.NewGuid(), emailGetter);
        _dbContext.Sources.Add(emailSource);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return emailSource.AsDto();
    }
    
    public async Task<EmailSourceDto> AddPhoneSource(string phoneGetter, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(phoneGetter);
        
        var phoneSource = new EmailSource(Guid.NewGuid(), phoneGetter);
        _dbContext.Sources.Add(phoneSource);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return phoneSource.AsDto();
    }

    public async Task<IReadOnlyCollection<ReportDto>> GetAllReports()
    {
        return await _dbContext.Reports.Select(report => report.AsDto()).ToListAsync();
    }

    public async Task<AdminDto> AddAdminAsync(string name, string surname, CancellationToken cancellationToken) // метод для теста, иначе мы не сможем добавить админа, ведь только у него есть возможность добавлять манагеров в нашу систему
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(surname);
        
        var admin = new Admin(Guid.NewGuid(), name, surname);
        _dbContext.Admins.Add(admin);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return admin.AsDto();
    }
}