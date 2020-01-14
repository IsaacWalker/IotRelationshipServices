/***************************************************
    SettingController.cs

    Isaac Walker
****************************************************/


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.SettingService.Contracts;
using Web.Iot.SettingService.Models;
using Web.Iot.SettingService.Settings;

namespace Web.Iot.SettingService.Controllers
{
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ILogger m_logger;


        private readonly ISettingProcessor m_processor;


        public SettingController(ISettingProcessor processor, ILogger<SettingController> logger)
        {
            m_processor = processor;
            m_logger = logger;
        }


        /// <summary>
        /// Gets the current settings as set by the remote service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/current")]
        public async Task<IActionResult> GetCurrent()
        {
            GetCurrentSettingsResponse response = await m_processor.Run(Shared.Message.Request.Empty);

            if(response.Success)
            {
                return Ok(response.SettingsModel);
            }

            return NotFound();
            
        }


        /// <summary>
        /// Used to set the current settings in the service.
        /// </summary>
        /// <param name="settingsModel">The set of settings</param>
        /// <param name="SetToCurrent">Will this be the new currently used set of settings</param>
        /// <returns>Returns 200 with the Id of the settings, which may already exist</returns>
        [HttpPost]
        [Route("api/[controller]/current")]
        public async Task<IActionResult> PostCurrent(SettingsModel settingsModel /*, [FromQuery] bool SetToCurrent = false*/)
        {
            bool is_valid = ValidateSettingsModel(settingsModel);

            if (!is_valid)
            {
                return BadRequest();
            }

            SetCurrentSettingsResponse response = await m_processor.Run(new SetCurrentSettingsRequest(settingsModel));

            return Ok(response.SettingsEntryId);
        }


        /// <summary>
        /// Gets the Settings Entry given an Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entry</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get([FromQuery] int id)
        {
            // TODO
            return Ok(id);
        }


        /// <summary>
        /// Creates a Setting Entry if not present
        /// </summary>
        /// <param name="settingModel"></param>
        /// <returns>The Id of the entry</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(SettingModel settingModel)
        {
            // TODO
            return Ok(settingModel);
        }


        private bool ValidateSettingsModel(SettingsModel settingsModel)
        {
            return settingsModel != null &&
                settingsModel.Settings != null &&
                settingsModel.Settings.All(S => !string.IsNullOrWhiteSpace(S.Name) &&
                   !string.IsNullOrWhiteSpace(S.Type) && !string.IsNullOrWhiteSpace(S.Value) &&
                   SettingType.ValidTypes.Contains(S.Type) &&
                   SettingType.ParseTable[S.Type].Invoke(S.Value))
                && settingsModel.Settings.All(S => settingsModel.Settings.Count(C=>C.Name == S.Name)==1);
        }
    }
}