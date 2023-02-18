using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.EntityTypesConfigurations;
using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;
using MessageProcessingSystem.DataAccess.Models.Messages;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.DataAccess;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Message> Messages { get; private set; } = null!;
    public DbSet<Manager> Managers { get; private set; } = null!;
    public DbSet<Subordinate> Subordinates { get; private set; } = null!;
    public DbSet<Source> Sources { get; private set; } = null!;
    public DbSet<Report> Reports { get; private set; } = null!;
    public DbSet<Account> Accounts { get; private set; } = null!;
    public DbSet<Admin> Admins { get; private set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeManagerConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeSubordinateConfiguration());
        modelBuilder.ApplyConfiguration(new SourceConfiguration());
        modelBuilder.ApplyConfiguration(new ReportConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
    }
}