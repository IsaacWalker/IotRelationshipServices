/***************************************************
    SettingsEntry.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// An Set of Settings (Entry)
    /// </summary>
    public class SettingsEntry
    { 
        /// <summary>
        /// Id of SettingsEntry
        /// </summary>
        public int SettingsEntryId { get; set; }


        /// <summary>
        /// Junction table
        /// </summary>
        public virtual IList<SettingsEntrySetting> SettingsEntrySettings { get; set; } = new List<SettingsEntrySetting>();
    }
}
