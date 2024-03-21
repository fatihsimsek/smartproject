using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartProject.Api.ActionResults;
using SmartProject.Application.Identity;

namespace SmartProject.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
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

    [HttpPost]
    [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var userDto = await _mediator.Send(new UserLoginCommand() { });
        return Ok(userDto);
    }
}

