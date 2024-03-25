using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartProject.Api.ActionResults;
using SmartProject.Application.Identity;

namespace SmartProject.Api.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator,
                                    ILogger<AuthenticationController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var userTokenDto = await _mediator.Send(new UserLoginCommand() { Email = userLoginDto.Email, Password = userLoginDto.Password });
        return Ok(userTokenDto);
    }
}

