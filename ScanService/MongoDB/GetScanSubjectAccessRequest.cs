using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    public class GetScanSubjectAccessRequest : Request
    {
        public readonly int DeviceId;


        public GetScanSubjectAccessRequest(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
