using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.SettingService.Settings
{
    public class SettingsEntrySetting
    {
        public string Name { get; set; }


        public string Value { get; set; }


        public string Type { get; set; }


        public Guid SettingsEntryId { get; set; }


        public Setting Setting { get; set; }


        public SettingsEntry SettingsEntry { get; set; }
    }
}
