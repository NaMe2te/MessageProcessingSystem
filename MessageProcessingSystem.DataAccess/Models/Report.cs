using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.DataAccess.Models;

public class Report
{
    public Report(Guid id, Guid managerIdId, DateOnly startOfInterval, DateOnly endOfInterval, int emailMessage, int phoneMessage, int parsedMessageCount, int allMessagesFoInterval)
    {
        Id = id;
        ParsedMessageCount = parsedMessageCount;
        ManagerId = managerIdId;
        StartOfInterval = startOfInterval;
        EndOfInterval = endOfInterval;
        EmailMessage = emailMessage;
        PhoneMessage = phoneMessage;
        AllMessagesFoInterval = allMessagesFoInterval;
    }

    protected Report() { }

    public Guid Id { get; init; }
    public DateOnly StartOfInterval { get; init; }
    public DateOnly EndOfInterval { get; init; }
    public int EmailMessage { get; init; }
    public int PhoneMessage { get; init; }
    public int ParsedMessageCount { get; init; }
    public int AllMessagesFoInterval { get; init; }
    public virtual Guid ManagerId { get; init; }
}