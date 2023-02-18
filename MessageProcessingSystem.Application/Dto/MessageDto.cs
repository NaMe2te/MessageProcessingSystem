namespace MessageProcessingSystem.Application.Dto;

public record MessageDto(Guid Id, string Status, string Text, DateOnly ReceiptDate, Guid SubordinateId = default);