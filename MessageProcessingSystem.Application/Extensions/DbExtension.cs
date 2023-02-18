using MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessingSystem.Application.Extensions;

public static class DbSetExtensions
{
    public static async Task<T> GetEntityAsync<T>(this DbSet<T> set, Guid id, CancellationToken cancellationToken = default)
        where T : class
    {
        return await set.FindAsync(new object[] {id}, cancellationToken) ?? throw new EntityNotFoundException<T>(id);
    }
}