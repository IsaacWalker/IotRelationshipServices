using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Models.Setting;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    public class RegisterSettingRequest : Request
    {
        public readonly List<SettingModel> Settings;


        public RegisterSettingRequest(List<SettingModel> Settings)
        {
            this.Settings = Settings;
        }
    }
}
