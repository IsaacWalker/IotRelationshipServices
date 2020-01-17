/***************************************************
    ConfigurationModel.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.Shared.Setting.Models
{
    /// <summary>
    /// The model of a Configuration 
    /// </summary>
    public class ConfigurationModel
    {
        public int Id { get; set; }

        public List<SettingModel> Settings { get; set; }
    }
}
