using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.Application.Mapping;

public static class SubordinateMapping
{
    public static SubordinateDto AdDto(this Subordinate subordinate)
        => new SubordinateDto(subordinate.Id, subordinate.Name, subordinate.Surname, subordinate.Boss.Id,
            subordinate.Messages.Select(message => message.AsDto()).ToList());
}