using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.DataAccess.Abstractions;

public abstract class Message
{
    public Message(Guid id, string text)
    {
        Text = text;
        Id = id;
        ReceiptDate = DateOnly.FromDateTime(DateTime.Now);
        Status = "NEW";
    }

    protected Message() { }
    public Guid Id { get; init; }

    public string Status { get; private set; }
    public string Text { get; init; }
    public DateOnly ReceiptDate { get; init; }

    public virtual Subordinate? WhoLooked { get; private set; }

    public void SetStatusViewed(Subordinate employee)
    {
        if (Status == "VIEWED" || Status == "ANSWERED")
            throw new Exception();

        WhoLooked = employee;
        Status = "VIEWED";
    }

    public void SetStatusAnswered(Subordinate employee)
    {
        if (Status == "ANSWERED")
            throw new Exception();

        WhoLooked = employee;
        Status = "ANSWERED";
    }
}