/***************************************************
    ConfigurationModel.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.Models.Setting
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
