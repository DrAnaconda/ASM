using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AntiScreenMeter.WebApi.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class ScreenMeterControlController : ControllerBase
    {
        public ScreenMeterControlController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}