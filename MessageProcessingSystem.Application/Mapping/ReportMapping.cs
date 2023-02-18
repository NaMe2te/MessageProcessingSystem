using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models;

namespace MessageProcessingSystem.Application.Mapping;

public static class ReportMapping
{
    public static ReportDto AsDto(this Report report)
        => new ReportDto(report.Id, report.ManagerId, report.StartOfInterval, report.EndOfInterval, report.EmailMessage,
            report.PhoneMessage, report.ParsedMessageCount, report.AllMessagesFoInterval);
}