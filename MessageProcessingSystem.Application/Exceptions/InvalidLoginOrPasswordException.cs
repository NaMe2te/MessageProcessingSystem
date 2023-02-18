namespace MessageProcessingSystem.Application.Exceptions;

public class InvalidLoginOrPasswordException : ApplicationException
{
    public InvalidLoginOrPasswordException()
        : base("Invalid username or password") { }
}