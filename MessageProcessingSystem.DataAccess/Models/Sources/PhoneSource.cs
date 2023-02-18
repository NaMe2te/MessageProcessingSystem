using MessageProcessingSystem.DataAccess.Abstractions;
using MessageProcessingSystem.DataAccess.Models.Messages;

namespace MessageProcessingSystem.DataAccess.Models.Sources;

public class PhoneSource : Source
{
    public PhoneSource(Guid id, string phoneGetter)
        : base(id)
    {
        PhoneGetter = phoneGetter;
        Messages = new List<PhoneMessage>();
    }

    public string PhoneGetter { get; init; }
    public virtual ICollection<PhoneMessage> Messages { get; init; }
}