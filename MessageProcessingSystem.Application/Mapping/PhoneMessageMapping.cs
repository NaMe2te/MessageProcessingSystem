using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Messages;

namespace MessageProcessingSystem.Application.Mapping;

public static class PhoneMessageMapping
{
    public static MessageDto AdDto(this PhoneMessage message)
        => message.WhoLooked is null ? new MessageDto(message.Id, message.Status, message.Text, message.ReceiptDate) : new MessageDto(message.Id, message.Status, message.Text, message.ReceiptDate, message.WhoLooked.Id);
}