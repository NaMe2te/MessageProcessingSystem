using MessageProcessingSystem.DataAccess.Abstractions;

namespace MessageProcessingSystem.DataAccess.Models.Messages;

public class EmailMessage : Message
{
    public EmailMessage(Guid id, string emailSender, string text)
        : base(id, text)
    {
        EmailSender = emailSender;
    }

    public string EmailSender { get; init; }
}