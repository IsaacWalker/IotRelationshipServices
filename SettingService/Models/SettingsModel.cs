/***************************************************
    SettingsModel.cs

    Isaac Walker
****************************************************/

using Web.Iot.SettingService.Settings;
using System.Collections.Generic;

namespace Web.Iot.SettingService.Models
{
    /// <summary>
    /// The model of a Settings Entry 
    /// </summary>
    public class SettingsModel
    {
        public List<Setting> Settings { get; set; }
    }
}
