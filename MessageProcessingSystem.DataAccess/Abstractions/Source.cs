namespace MessageProcessingSystem.DataAccess.Abstractions;

public abstract class Source
{
    public Source(Guid id)
    {
        Id = id;
    }

    protected Source() { }
    public Guid Id { get; init; }
}