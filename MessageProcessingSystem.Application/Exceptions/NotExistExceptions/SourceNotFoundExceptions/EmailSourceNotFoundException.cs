using MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;

namespace MessageProcessingSystem.Application.Exceptions.NotExistExceptions.SourceNotFoundExceptions;

public class EmailSourceNotFoundException : NotFoundException
{
    public EmailSourceNotFoundException(string email) : base($"Email source with {email} email address not found") { }
}