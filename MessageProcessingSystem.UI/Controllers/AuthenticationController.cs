using System.Security.Claims;
using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Services;
using MessageProcessingSystem.UI.Models.Accounts;
using MessageProcessingSystem.UI.Models.Employees;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = MessageProcessingSystem.Application.Services.IAuthenticationService;

namespace MessageProcessingSystem.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAdminService _adminService;

    public AuthenticationController(IAuthenticationService authenticationService, IAdminService adminService)
    {
        _authenticationService = authenticationService;
        _adminService = adminService;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccountDto>> LoginAsync([FromBody] CreateAccountModel model)
    {
        AccountDto accountDto = await _authenticationService.LoginAsync(model.AccountName, model.AccountPassword, CancellationToken);

        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Sid, accountDto.Name),
            new Claim(ClaimTypes.Role, accountDto.Role),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        return Ok(accountDto);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync();
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("register-admin")]
    public async Task<ActionResult<AccountDto>> RegisterAdminAsync([FromQuery] CreateEmployeeModel employeeModel, [FromQuery] CreateAccountModel accountModel) // костыль метод, чтобы все работало
    {
        AdminDto adminDto = await _adminService.AddAdminAsync(employeeModel.Name, employeeModel.Surname, CancellationToken);
        AccountDto accountDto = await _authenticationService.RegisterAsync(accountModel.AccountName, accountModel.AccountPassword,
            adminDto.Id, CancellationToken);
        return Ok(accountDto);
    }
}