using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.DataAccess.Models;

namespace MessageProcessingSystem.Application.Mapping;

public static class AccountMapping
{
    public static AccountDto AsDto(this Account account)
        => new AccountDto(account.AccountRole.ToString("G"), account.Name, account.Password, account.Employee.Id);
}