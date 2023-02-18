using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models.Messages;

namespace MessageProcessingSystem.DataAccess.Models.Sources;

public class EmailSource : Source
{
    public EmailSource(Guid id, string emailGetter)
        : base(id)
    {
        EmailGetter = emailGetter;
        Messages = new List<EmailMessage>();
    }

    public string EmailGetter { get; init; }
    public virtual ICollection<EmailMessage> Messages { get; init; }
}