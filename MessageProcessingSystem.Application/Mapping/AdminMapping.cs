using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models.Employees;

namespace MessageProcessingSystem.Application.Mapping;

public static class AdminMapping
{
    public static AdminDto AsDto(this Admin admin)
        => new AdminDto(admin.Name, admin.Surname, admin.Id);
}