using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.SettingService.Contracts
{
    public class GetSettingResponse : Response
    {
        public readonly ConfigurationModel Configuration;


        public GetSettingResponse(bool Success, ConfigurationModel configuration) : base(Success)
        {
            Configuration = configuration;
        }
    }
}
