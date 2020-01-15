﻿/***************************************************
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
                return Ok(response.Configuration);
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
        public async Task<IActionResult> PostCurrent(ConfigurationModel configurationModel /*, [FromQuery] bool SetToCurrent = false*/)
        {
            bool is_valid = ValidateSettingsModel(configurationModel);

            if (!is_valid)
            {
                return BadRequest();
            }

            SetCurrentSettingsResponse response = await m_processor.Run(new SetCurrentSettingsRequest(configurationModel));

            return Ok(response.ConfigurationId);
        }


        /// <summary>
        /// Gets the Settings Entry given an Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The entry</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            GetSettingResponse response = await m_processor.Run(new GetSettingRequest(id));

            if(!response.Success)
            {
                return NotFound();
            }

            return Ok(response.Configuration);
        }


        /// <summary>
        /// Creates a Setting Entry if not present
        /// </summary>
        /// <param name="settingModel"></param>
        /// <returns>The Id of the entry</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(SettingModel configurationModel)
        {
            // TODO
            return Ok(configurationModel);
        }


        private bool ValidateSettingsModel(ConfigurationModel configurationModel)
        {
            bool valid = configurationModel != null &&
                configurationModel.Settings != null &&
                configurationModel.Settings.All(S => !string.IsNullOrWhiteSpace(S.Name) &&
                   !string.IsNullOrWhiteSpace(S.Type) && !string.IsNullOrWhiteSpace(S.Value) &&
                   SettingType.ValidTypes.Contains(S.Type) &&
                   SettingType.ParseTable[S.Type].Invoke(S.Value))
                && configurationModel.Settings.All(S => configurationModel.Settings.Count(C => C.Name == S.Name) == 1);

            return valid;
        }
    }
}