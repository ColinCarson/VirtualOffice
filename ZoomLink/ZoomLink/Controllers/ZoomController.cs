namespace ZoomLink.Controllers
{    
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using ZoomLink.Common.Models;

    [ApiController]
    [Route("[controller]")]
    public class ZoomController : ControllerBase
    {
        private readonly ILogger<ZoomController> _logger;

        public ZoomController(ILogger<ZoomController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return new List<Contact>();
        }
    }
}
