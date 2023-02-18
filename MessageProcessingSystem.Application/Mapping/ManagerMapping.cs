using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.Application.Mapping;

public static class ManagerMapping
{
    public static ManagerDto AsDto(this Manager manager)
        => new ManagerDto(manager.Id, manager.Name, manager.Surname, manager.Subordinates.Select(subordinate => subordinate.AdDto()).ToList());
}