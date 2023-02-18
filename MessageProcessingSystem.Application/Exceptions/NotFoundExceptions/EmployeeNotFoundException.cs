namespace MessageProcessingSystem.Application.Exceptions.NotFoundExceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid employeeId)
        : base($"Employee with id \"{employeeId}\" not found") { }
}