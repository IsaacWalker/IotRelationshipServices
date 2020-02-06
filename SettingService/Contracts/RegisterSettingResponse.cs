using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    public class RegisterSettingResponse : Response
    {
        public readonly int Id;


        public RegisterSettingResponse(int id, bool Success) : base(Success)
        {
            Id = id;
        }
    }
}
