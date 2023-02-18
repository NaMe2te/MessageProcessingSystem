using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Abstractions;

namespace MessageProcessingSystem.Application.Mapping;

public static class MessageMapping
{
    public static MessageDto AsDto(this Message message)
        => message.WhoLooked is null ? new MessageDto(message.Id, message.Status, message.Text, message.ReceiptDate) : new MessageDto(message.Id, message.Status, message.Text, message.ReceiptDate, message.WhoLooked.Id);
    
}