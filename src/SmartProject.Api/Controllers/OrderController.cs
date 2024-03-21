using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartProject.Api.ActionResults;
using SmartProject.Application.Order;

namespace SmartProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Envelope), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long id)
        {
            var orderDto = await _mediator.Send(new GetOrderQuery() { OrderId = id });
            return Ok(orderDto);
        }
    }
}

