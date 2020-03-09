using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.DeviceService.Devices;
using Web.Iot.Models.Device;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class GetDeviceSAResponse : Response
    {
        public readonly Device DeviceModel;


        public GetDeviceSAResponse(Device deviceModel, bool Success) : base(Success)
        {
            DeviceModel = deviceModel;
        }
    }
}
