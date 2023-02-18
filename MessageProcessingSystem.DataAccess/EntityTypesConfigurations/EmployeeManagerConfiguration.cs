using MessageProcessingSystem.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageProcessingSystem.DataAccess.EntityTypesConfigurations;

public class EmployeeManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasMany(manager => manager.Subordinates)
            .WithOne(subordinate => subordinate.Boss);
        builder.HasMany(manager => manager.Reports);
    }
}