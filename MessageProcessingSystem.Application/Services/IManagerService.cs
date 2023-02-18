using MessageProcessingSystem.Application.Dto;

namespace MessageProcessingSystem.Application.Services;

public interface IManagerService
{
    Task<SubordinateDto> AddSubordinateAsync(string name, string surname, string managerAccountName,
        CancellationToken cancellationToken);
    Task<IReadOnlyCollection<SubordinateDto>> GetSubordinatesByManagerAsync(string managerAccountName, CancellationToken cancellationToken);
    Task<ReportDto> GetReportAsync(DateOnly startOfInterval, DateOnly endOfInterval, string managerAccountName, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<ReportDto>> GetAllManagerReportsAsync(string managerAccountName, CancellationToken cancellationToken);
}