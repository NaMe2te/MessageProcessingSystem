using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models.Sources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageProcessingSystem.DataAccess.EntityTypesConfigurations;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.HasDiscriminator<string>("source_type")
            .HasValue<EmailSource>("email_source_type")
            .HasValue<PhoneSource>("phone_source_type");
    }
}