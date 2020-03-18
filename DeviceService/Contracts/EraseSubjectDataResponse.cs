using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class EraseSubjectDataResponse : Response
    {
        public EraseSubjectDataResponse(bool Success) : base(Success)
        {
        }
    }
}
