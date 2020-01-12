/***************************************************
    SettingController.cs

    Isaac Walker
****************************************************/


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.SettingService.Models;

namespace Web.Iot.SettingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ILogger m_logger;


        public SettingController(ILogger<SettingController> logger)
        {
            m_logger = logger;
        }


        /// <summary>
        /// Gets the current settings as set by the remote service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            // TODO
            return Ok();
        }


        /// <summary>
        /// Used to register a set of settings in the service.
        /// </summary>
        /// <param name="settingsModel">The set of settings</param>
        /// <param name="SetToCurrent">Will this be the new currently used set of settings</param>
        /// <returns>Returns 200 with the Id of the settings, which may already exist</returns>
        [HttpPost]
        public IActionResult Post(SettingsModel settingsModel, [FromQuery] bool SetToCurrent = false)
        {
            // TODO
            if(settingsModel == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}