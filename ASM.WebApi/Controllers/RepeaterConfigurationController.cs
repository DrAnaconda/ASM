using System;
using ASM.ApiServices.SMRepeater.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(RepeaterConfiguration), StatusCodes.Status200OK)]
        public ActionResult SwitchPause()
        {
            _repeaterConfiguration.isPaused = !_repeaterConfiguration.isPaused;
            return Ok(_repeaterConfiguration);
        }
        
        /// <summary>
        /// Current time + X minutes = time when we need to pause ASM
        /// </summary>
        /// <param name="minutesInAdvance"></param>
        /// <returns></returns>
        [HttpPatch("set-auto-pause/minutes-advancing")]
        [ProducesResponseType(typeof(RepeaterConfiguration), StatusCodes.Status200OK)]
        public ActionResult SetAutoPauseMinutesScale([FromQuery] int minutesInAdvance)
        {
            _repeaterConfiguration.whenPause = DateTime.UtcNow.AddMinutes(minutesInAdvance);
            return Ok(_repeaterConfiguration);
        }
        
        [HttpPatch("set-auto-pause/hours-advancing")]
        [ProducesResponseType(typeof(RepeaterConfiguration), StatusCodes.Status200OK)]
        public ActionResult SetAutoPauseHoursScale([FromQuery] int hoursInAdvance)
        {
            _repeaterConfiguration.whenPause = DateTime.UtcNow.AddHours(hoursInAdvance);
            return Ok(_repeaterConfiguration);
        }
        
        [HttpPatch("set-auto-pause/reset")]
        [ProducesResponseType(typeof(RepeaterConfiguration), StatusCodes.Status200OK)]
        public ActionResult ResetAutoPauseConfiguration()
        {
            _repeaterConfiguration.whenPause = null;
            return Ok(_repeaterConfiguration);
        }
    }
}