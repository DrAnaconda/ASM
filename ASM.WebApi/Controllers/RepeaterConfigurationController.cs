using ASM.ApiServices.SMRepeater.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASM.WebApi.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class RepeaterConfigurationController : ControllerBase
    {
        private readonly RepeaterConfiguration _repeaterConfiguration;

        public RepeaterConfigurationController(
            IOptions<RepeaterConfiguration> repeaterConfiguration)
        {
            _repeaterConfiguration = repeaterConfiguration.Value;
        }

        [HttpGet]
        public ActionResult GetCurrentRepeaterConfigurationState()
        {
            return Ok(_repeaterConfiguration);
        }

        [HttpPatch("toggle-pause")]
        public ActionResult SwitchPause()
        {
            _repeaterConfiguration.isPaused = !_repeaterConfiguration.isPaused;
            return Ok(_repeaterConfiguration);
        }
    }
}