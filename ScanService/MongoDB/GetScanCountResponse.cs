using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    public class GetScanCountResponse : Response
    {
        public readonly long Count;


        public GetScanCountResponse(bool Success, long Count) : base(Success)
        {
            this.Count = Count;
        }
    }
}
