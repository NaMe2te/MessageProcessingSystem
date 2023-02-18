namespace MessageProcessingSystem.Application.Exceptions.NotExistExceptions;

public class NotExistException : ApplicationException
{
    public NotExistException(string? message) : base(message) { }
}