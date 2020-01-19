/***************************************************
    HomeModel.cs

    Isaac Walker
****************************************************/


using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Web.Iot.Shared.Setting;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.PortalService.Models.ViewModels
{
    /// <summary>
    /// Model for the home screen
    /// </summary>
    public class HomeModel
    {
        /// <summary>
        /// Did the setting exist
        /// </summary>
        public bool SettingExists = false;


        /// <summary>
        /// The configuration
        /// </summary>
        public ConfigurationModel Configuration { get; set; }



        public List<SelectListItem> ValidSettingTypes { get; set; } = SettingType.ValidTypes
            .Select(S => new SelectListItem { Text = S, Value = S })
            .ToList();
    }
}
