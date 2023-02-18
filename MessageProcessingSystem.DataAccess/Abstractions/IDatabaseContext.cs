using MessageProcessingSystem.DataAccess.Models;
using MessageProcessingSystem.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.DataAccess.Abstractions;

public interface IDatabaseContext
{
    DbSet<Message> Messages { get; }
    public DbSet<Manager> Managers { get;  }
    public DbSet<Subordinate> Subordinates { get; }
    public DbSet<Source> Sources { get; }
    public DbSet<Report> Reports { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}