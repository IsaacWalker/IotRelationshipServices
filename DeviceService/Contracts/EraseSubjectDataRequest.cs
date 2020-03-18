using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class EraseSubjectDataRequest : Request
    {
        public int DeviceId { get; private set; }

        public EraseSubjectDataRequest(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
