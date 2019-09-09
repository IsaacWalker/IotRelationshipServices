/***************************************************
    ScanController.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.ScanService.Models;

namespace Web.Iot.ScanService.Controllers
{
    [Route("api/[controller]")]
    public class ScanController : Controller
    {
        private readonly ILogger m_logger;

        public ScanController(ILogger<ScanController> logger)
        {
            m_logger = logger;
        }

        /// <summary>
        /// Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        public void Post([FromQuery] long DeviceId, [FromBody] ScanModel Scan)
        {
            m_logger.LogDebug(LogEventId.ScanPostStart, string.Format("Scan Received: From {0}, On {1}, Wifi: {2}, Bluetooth: {3}, Kinematics: {4}",
                 DeviceId, Scan.DateTime, Scan.IsWifiEnabled, Scan.IsBluetoothEnabled, Scan.IsKinematicsEnabled));

            //TODO - Log to DB

            m_logger.LogDebug(LogEventId.ScanPostEnd, "Scan processed.");
        }


        /// <summary>
        /// Batch Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        public void PostBatch([FromBody] ScanBatchModel Scans)
        {
            m_logger.LogDebug(LogEventId.ScanBatchPostStart, string.Format("Scans Received: From {0}, Number {1}", 
                Scans.DeviceId, Scans.Scans.Count));

            // TODO Log to DB

            m_logger.LogDebug(LogEventId.ScanBatchPostEnd, "Scan Batch processed");
        }
    }
}
