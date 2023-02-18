using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Services;
using MessageProcessingSystem.UI.Models.Accounts;
using MessageProcessingSystem.UI.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingSystem.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminPolicy")]

public class AdminController : Controller
{
    private readonly IAdminService _adminService;
    private readonly IAuthenticationService _authenticationService;

    public AdminController(IAdminService adminService, IAuthenticationService authenticationService)
    {
        _adminService = adminService;
        _authenticationService = authenticationService;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;
    
    [HttpPost("add-manager")]
    public async Task<ActionResult<AccountDto>> AddManagerAsync([FromQuery] CreateEmployeeModel employeeModel, [FromQuery] CreateAccountModel accountModel)
    {
        ManagerDto subordinate = await _adminService.AddManagerAsync(employeeModel.Name, employeeModel.Surname, CancellationToken);
        AccountDto registeredAccount = await _authenticationService.RegisterAsync(accountModel.AccountName, accountModel.AccountPassword, subordinate.Id, CancellationToken);
        return Ok(registeredAccount);
    }

    [HttpPost("add-email-source")]
    public async Task<ActionResult<EmailSourceDto>> AddEmailSourceAsync(string emailGetter)
    {
        EmailSourceDto emailSource = await _adminService.AddEmailSource(emailGetter, CancellationToken);
        return Ok(emailSource);
    }
    
    [HttpPost("add-phone-source")]
    public async Task<ActionResult<EmailSourceDto>> AddPhoneSourceAsync(string phoneGetter)
    {
        EmailSourceDto phoneSource = await _adminService.AddEmailSource(phoneGetter, CancellationToken);
        return Ok(phoneSource);
    }
}