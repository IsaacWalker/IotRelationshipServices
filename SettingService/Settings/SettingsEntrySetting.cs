/***************************************************
    SettingsEntrySetting.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// Junction table for Setting - SettingEntry
    /// </summary>
    public class SettingsEntrySetting
    {
        /// <summary>
        /// PK/FK - Id of the setting
        /// </summary>
        public int SettingId { get; set; }


        /// <summary>
        /// PK/FK - Id of the Entry
        /// </summary>
        public int SettingsEntryId { get; set; }


        public Setting Setting { get; set; }


        public SettingsEntry SettingsEntry { get; set; }
    }
}
