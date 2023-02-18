namespace MessageProcessingSystem.Application.Dto;

public record SubordinateDto(Guid Id, string Name, string Surname, Guid ManagerId, IReadOnlyCollection<MessageDto> Messages);