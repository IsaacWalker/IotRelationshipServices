﻿/***************************************************
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
        public int Id { get; set; }

        public List<SettingModel> Settings { get; set; }
    }


    /// <summary>
    /// The model of an individual setting
    /// </summary>
    public class SettingModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }
    }

}
