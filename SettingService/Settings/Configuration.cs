/***************************************************
    Configuration.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// An Set of Settings comprises a unique configuration
    /// </summary>
    public class Configuration
    { 
        /// <summary>
        /// Id of the configuration
        /// </summary>
        public int ConfigurationId { get; set; }


        /// <summary>
        /// Junction table
        /// </summary>
        public virtual IList<ConfigurationSetting> ConfigurationSettings { get; set; } = new List<ConfigurationSetting>();
    }
}
