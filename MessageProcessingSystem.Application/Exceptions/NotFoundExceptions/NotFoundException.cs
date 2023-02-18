namespace MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) 
        : base(message) { }
}