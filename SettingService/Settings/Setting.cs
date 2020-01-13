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
        public string Name { get; set; }


        public string Value { get; set; }


        public string Type { get; set; }


        public virtual ICollection<SettingsEntrySetting> SettingsEntrySettings { get; set; } = new HashSet<SettingsEntrySetting>();
    }
}
