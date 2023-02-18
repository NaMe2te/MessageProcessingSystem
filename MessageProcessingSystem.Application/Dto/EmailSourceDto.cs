namespace MessageProcessingSystem.Application.Dto;

public record EmailSourceDto(Guid Id, string EmailGetter, IReadOnlyCollection<MessageDto> Messages);