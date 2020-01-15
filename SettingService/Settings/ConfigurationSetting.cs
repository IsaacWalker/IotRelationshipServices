/***************************************************
    ConfigurationSetting.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// Junction table for Setting - SettingEntry
    /// </summary>
    public class ConfigurationSetting
    {
        /// <summary>
        /// PK/FK - Id of the setting
        /// </summary>
        public int SettingId { get; set; }


        /// <summary>
        /// PK/FK - Id of the Configuration
        /// </summary>
        public int ConfigurationId { get; set; }


        public Setting Setting { get; set; }


        public Configuration Configuration { get; set; }
    }
}
