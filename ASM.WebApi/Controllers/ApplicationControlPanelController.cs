using ASM.ApiServices.SMRepeater.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASM.WebApi.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class ApplicationControlPanelController : ControllerBase
    {
        private readonly RepeaterConfiguration _repeaterConfiguration;
        
        public ApplicationControlPanelController(
            IOptions<RepeaterConfiguration> configurationOptions)
        {
            _repeaterConfiguration = configurationOptions.Value;
        }

        [HttpGet]
        public ActionResult GetCurrentConfiguration()
        {
            return Ok(_repeaterConfiguration);
        }
    }
}