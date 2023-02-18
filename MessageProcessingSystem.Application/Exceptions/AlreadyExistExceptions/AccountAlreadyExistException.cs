namespace MessageProcessingSystem.Application.Exceptions.AlreadyExistExceptions;

public class AccountAlreadyExistException : AlreadyExistException
{
    public AccountAlreadyExistException(string accountName)
        : base($"Account with name \"{accountName}\" already exist") { }
}