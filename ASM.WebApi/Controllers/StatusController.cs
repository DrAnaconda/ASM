using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [ApiController, Route("[controller]"), AllowAnonymous]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult ReportUptime()
        {
            return Ok();
        }
    }
}