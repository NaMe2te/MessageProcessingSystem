using System.Security.Claims;
using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingSystem.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "SubordinatePolicy")]

public class SubordinateController : Controller
{
    private readonly ISubordinatesService _subordinatesService;

    public SubordinateController(ISubordinatesService subordinatesService)
    {
        _subordinatesService = subordinatesService;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;
    
    [HttpPost("view-message")]
    public async Task<ActionResult<MessageDto>> ViewMessageAsync(Guid messageId)
    {
        string subordinateAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        MessageDto messageDto = await _subordinatesService.ViewMessageAsync(messageId, subordinateAccountName, CancellationToken);
        return Ok(messageDto);
    }

    [HttpPost("reply-to-message")]
    public async Task<ActionResult<AccountDto>> ReplyToMessageAsync(Guid messageId)
    {
        string subordinateAccountName = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Sid).Value;
        MessageDto messageDto = await _subordinatesService.ReplyToMessageAsync(messageId, subordinateAccountName, CancellationToken);
        return Ok(messageDto);
    }

    [HttpGet("get-new-messages")]
    public async Task<ActionResult<IReadOnlyCollection<MessageDto>>> GetNewMessages()
    {
        IReadOnlyCollection<MessageDto> messages = await _subordinatesService.GetNewMessagesAsync(CancellationToken);
        return Ok(messages);
    }
}