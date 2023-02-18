namespace MessageProcessingSystem.Application.Dto;

public record ReportDto(Guid Id, Guid ManagerId, DateOnly StartOfInterval, DateOnly EndOfInterval, int EmailMessage, int PhoneMessage, int ParsedMessageCount, int AllMessagesForInterval);