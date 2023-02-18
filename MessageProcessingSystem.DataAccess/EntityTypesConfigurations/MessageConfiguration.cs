using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageProcessingSystem.DataAccess.EntityTypesConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasDiscriminator<string>("message_type")
            .HasValue<EmailMessage>("email_type")
            .HasValue<PhoneMessage>("phone_type");

        builder.HasOne(message => message.WhoLooked)
            .WithMany(subordinate => subordinate.Messages);
    }
}