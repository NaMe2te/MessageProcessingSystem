namespace MessageProcessingSystem.Application.Dto;

public record PhoneSourceDto(Guid Id, string PhoneGetter, IReadOnlyCollection<MessageDto> Messages);