namespace MessageProcessingSystem.Application.Exceptions.NotExistExceptions;

public class AccountNotExistException : NotExistException
{
    public AccountNotExistException(string name) : base($"Account with {name} not exist") { }
}