using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    public class GetSettingRequest : Request
    {
        public readonly int Id;


        public GetSettingRequest(int id)
        {
            Id = id;
        }
    }
}
