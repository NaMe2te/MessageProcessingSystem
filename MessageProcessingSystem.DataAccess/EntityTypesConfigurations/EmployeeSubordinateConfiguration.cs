using MessageProcessingSystem.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageProcessingSystem.DataAccess.EntityTypesConfigurations;

public class EmployeeSubordinateConfiguration : IEntityTypeConfiguration<Subordinate>
{
    public void Configure(EntityTypeBuilder<Subordinate> builder)
    {
        builder.HasOne(subordinate => subordinate.Boss)
            .WithMany(manager => manager.Subordinates);
        builder.HasMany(subordinate => subordinate.Messages)
            .WithOne(message => message.WhoLooked);
    }
}