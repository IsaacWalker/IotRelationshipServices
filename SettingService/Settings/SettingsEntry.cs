/***************************************************
    SettingsEntry.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// An Set of Settings
    /// </summary>
    public class SettingsEntry
    { 
        public Guid SettingsEntryId { get; set; }


        public virtual ICollection<SettingsEntrySetting> SettingsEntrySettings { get; set; } = new HashSet<SettingsEntrySetting>();
    }
}
