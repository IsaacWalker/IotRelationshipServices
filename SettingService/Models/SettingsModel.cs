/***************************************************
    SettingsModel.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.SettingService.Models
{
    /// <summary>
    /// The model of a Settings Entry 
    /// </summary>
    public class SettingsModel
    {
        public Guid Id { get; set; }

        public List<SettingModel> Settings { get; set; }
    }

    public class SettingModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }
    }

}
