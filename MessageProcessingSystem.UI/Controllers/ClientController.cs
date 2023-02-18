using MessageProcessingSystem.Application.Dto;
using MessageProcessingSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageProcessingSystem.UI.Controllers;

[ApiController]
[Route("api[controller]")]

public class ClientController : Controller
{
    private readonly ISourceService _sourceService;

    public ClientController(ISourceService sourceService)
    {
        _sourceService = sourceService;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;
    
    [HttpPost("write-new-email-message")]
    public async Task<ActionResult<MessageDto>> WriteNewEmailMessageAsync(string getterEmail, string text, string senderEmail)
    {
        MessageDto messageDto = await _sourceService.WriteNewEmailMessageAsync(getterEmail, text, senderEmail, CancellationToken);
        return Ok(messageDto);
    }
    
    [HttpPost("write-new-phone-message")]
    public async Task<ActionResult<MessageDto>> WriteNewPhoneMessageAsync(string getterPhone, string text, string senderPhone)
    {
        MessageDto messageDto = await _sourceService.WriteNewEmailMessageAsync(getterPhone, text, senderPhone, CancellationToken);
        return Ok(messageDto);
    }
}