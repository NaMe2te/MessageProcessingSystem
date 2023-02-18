namespace MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;

public class EntityNotFoundException<T> : NotFoundException
where T : class 
{
    public EntityNotFoundException(Guid id) 
        : base($"{typeof(T).Name} with id {id} was not found.") { }
}