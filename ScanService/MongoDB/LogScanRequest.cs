/***************************************************
    LogScanRequest.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Models.MongoDB;

namespace Web.Iot.ScanService.MongoDB
{
    /// <summary>
    /// Request to Log Scans
    /// </summary>
    public sealed class LogScanRequest : Request
    {
        /// <summary>
        /// Scans
        /// </summary>
        public List<ScanModel> Scans { get; private set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="scans"></param>
        public LogScanRequest(long deviceId, List<ScanModel> scans)
        {
            Scans = scans;
            Scans.ForEach(S => S.DeviceId = deviceId);
        }
    }
}
