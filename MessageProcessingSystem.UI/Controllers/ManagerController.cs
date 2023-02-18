using System.Security.Claims;
using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Services;
using MessageProcessingSystem.UI.Models;
using MessageProcessingSystem.UI.Models.Accounts;
using MessageProcessingSystem.UI.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingSystem.UI.Controllers;

[ApiController]
[Authorize(Policy = "ManagerPolicy")]
[Route("api/[controller]")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;
    private readonly IAuthenticationService _authenticationService;
    
    public ManagerController(IManagerService managerService, IAuthenticationService authenticationService)
    {
        _managerService = managerService;
        _authenticationService = authenticationService;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("add-subordinate")]
    public async Task<ActionResult<AccountDto>> AddSubordinateAsync([FromQuery] CreateEmployeeModel employeeModel, [FromQuery] CreateAccountModel accountModel)
    {
        string managerAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        SubordinateDto subordinate = await _managerService.AddSubordinateAsync(employeeModel.Name, employeeModel.Surname, managerAccountName, CancellationToken);
        AccountDto registeredAccount = await _authenticationService.RegisterAsync(accountModel.AccountName, accountModel.AccountPassword, subordinate.Id, CancellationToken);
        return Ok(registeredAccount);
    }

    [HttpGet("get-subordinates")]
    public async Task<ActionResult<IReadOnlyCollection<SubordinateDto>>> GetSubordinatesAsync()
    {
        string managerAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        IReadOnlyCollection<SubordinateDto> subordinates = await _managerService.GetSubordinatesByManagerAsync(managerAccountName, CancellationToken);
        return Ok(subordinates);
    }

    [HttpPost("make-report")]
    public async Task<ActionResult<ReportDto>> MakeReportAsync([FromQuery] CreateReportModel createReportModel)
    {
        var startOfInterval = DateOnly.Parse(createReportModel.StartOfInterval);
        var endOfInterval = DateOnly.Parse(createReportModel.EndOfInterval);
        string managerAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        ReportDto report = await _managerService.GetReportAsync(startOfInterval, endOfInterval, managerAccountName, CancellationToken);
        return Ok(report);
    }

    [HttpGet("get-all-reports")]
    public async Task<ActionResult<IReadOnlyCollection<ReportDto>>> GetAllManagerReportsAsync()
    {
        string managerAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        IReadOnlyCollection<ReportDto> reports = await _managerService.GetAllManagerReportsAsync(managerAccountName, CancellationToken);
        return Ok(reports);
    }
}