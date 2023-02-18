namespace MessageProcessingSystem.Application.Dto;

public record ManagerDto(Guid Id, string Name, string Surname, IReadOnlyCollection<SubordinateDto> Subordinates);