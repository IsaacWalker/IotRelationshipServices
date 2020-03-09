using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Models.Device;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class GetDeviceSARequest : Request
    {
        public readonly int DeviceId;


        public GetDeviceSARequest(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
