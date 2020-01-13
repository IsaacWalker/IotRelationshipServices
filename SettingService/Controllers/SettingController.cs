/***************************************************
    SettingController.cs

    Isaac Walker
****************************************************/


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Web.Iot.SettingService.Models;
using Web.Iot.SettingService.Settings;

namespace Web.Iot.SettingService.Controllers
{
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ILogger m_logger;


        private readonly SettingServiceContext m_serviceContext;


        public SettingController(SettingServiceContext serviceContext, ILogger<SettingController> logger)
        {
            m_serviceContext = serviceContext;
            m_logger = logger;
        }


        /// <summary>
        /// Gets the current settings as set by the remote service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/current")]
        public IActionResult GetCurrent()
        {
            SettingsModel model = new SettingsModel();
            var current = m_serviceContext.SettingsEntries.First();

            var settings = m_serviceContext.Settings.Where(S => current.SettingsEntrySettings.Any(E => E.Setting == S));
            model.Settings = settings.Select(S => new SettingModel { Name = S.Name, Type = S.Type, Value = S.Value }).ToList();
            model.Id = current.SettingsEntryId;

            return Ok(model);
        }


        /// <summary>
        /// Used to set the current settings in the service.
        /// </summary>
        /// <param name="settingsModel">The set of settings</param>
        /// <param name="SetToCurrent">Will this be the new currently used set of settings</param>
        /// <returns>Returns 200 with the Id of the settings, which may already exist</returns>
        [HttpPost]
        [Route("api/[controller]/current")]
        public IActionResult PostCurrent(SettingsModel settingsModel /*, [FromQuery] bool SetToCurrent = false*/)
        {
            bool is_valid = ValidateSettingsModel(settingsModel);

            if (!is_valid)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get([FromQuery] int id)
        {
            // TODO
            return Ok(id);
        }


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