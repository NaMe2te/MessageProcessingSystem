namespace MessageProcessingSystem.Application.Exceptions.AlreadyExistExceptions;

public class AlreadyExistException : ApplicationException
{
    public AlreadyExistException(string? message) : base(message) { }
}