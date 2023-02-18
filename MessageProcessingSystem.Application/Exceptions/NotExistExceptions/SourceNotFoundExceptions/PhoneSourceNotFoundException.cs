using MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;

namespace MessageProcessingSystem.Application.Exceptions.NotExistExceptions.SourceNotFoundExceptions;

public class PhoneSourceNotFoundException : NotFoundException
{
    public PhoneSourceNotFoundException(string phoneNumber) : base($"Phone source with {phoneNumber} phone not found") { }
}