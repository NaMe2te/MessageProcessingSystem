using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Sources;

namespace MessageProcessingSystem.Application.Mapping;

public static class PhoneSourceMapping
{
    public static PhoneSourceDto AsDto(this PhoneSource phoneSource)
        => new PhoneSourceDto(phoneSource.Id, phoneSource.PhoneGetter, phoneSource.Messages.Select(message => message.AdDto()).ToList());
}