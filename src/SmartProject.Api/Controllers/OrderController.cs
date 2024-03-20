using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace SmartProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetValue")]
        public string Get()
        {
            return string.Empty;
        }
    }
}

