using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Enums;

namespace MessageProcessingSystem.DataAccess.Models.Messages;

public class PhoneMessage : Message
{
    public PhoneMessage(Guid id, string senderPhoneNumber, string text)
        : base(id, text)
    {
        SenderPhoneNumber = senderPhoneNumber;
    }

    public string SenderPhoneNumber { get; init; }
}