/***************************************************
    Setting.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// A unique setting with a name, type and value
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Id of Setting
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// The name of the setting
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The string value of the setting
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// The type of the setting
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// Junction table
        /// </summary>
        public virtual IList<ConfigurationSetting> ConfigurationSettings { get; set; } = new List<ConfigurationSetting>();

        
        public bool Equivalent(Setting setting)
        {
        
            return Name == setting.Name &&
             Type == setting.Type &&
             Value == setting.Value;
        }


    }
}
