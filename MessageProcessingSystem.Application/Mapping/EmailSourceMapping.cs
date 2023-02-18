using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Messages;
using MessageProcessingSystem.DataAccess.Models.Sources;

namespace MessageProcessingSystem.Application.Mapping;

public static class EmailSourceMapping
{
    public static EmailSourceDto AsDto(this EmailSource emailSource)
        => new EmailSourceDto(emailSource.Id, emailSource.EmailGetter,
            emailSource.Messages.Select(message => message.AsDto()).ToList());
}