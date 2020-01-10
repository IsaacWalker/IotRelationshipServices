/***************************************************
    ScanController.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.Shared.Message;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.ScanService.Models;
using Web.Iot.ScanService.MongoDB;
using Web.Iot.ScanService.MongoDB.Data;
using System.Collections.Generic;

namespace Web.Iot.ScanService.Controllers
{
    [Route("api/[controller]")]
    public class ScanController : Controller
    {
        private readonly ILogger m_logger;


        private readonly IProcessor<LogScanRequest, LogScanResponse> m_processor;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="logger"></param>
        public ScanController(IProcessor<LogScanRequest, LogScanResponse> processor, ILogger<ScanController> logger)
        {
            m_processor = processor;
            m_logger = logger;
        }


        /// <summary>
        /// Batch Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScanBatchModel ScanBatch)
        {
            if(ScanBatch.Scans == null || ScanBatch.Scans.Count == 0)
            {
                return BadRequest();
            }

            m_logger.LogDebug(LogEventId.ScanBatchPostStart, string.Format("Scans Received: From {0}, Number {1}",
                ScanBatch.DeviceId, ScanBatch.Scans.Count));

            LogScanRequest Request = new LogScanRequest(ScanBatch.DeviceId, ScanBatch.Scans);
            LogScanResponse Response = await m_processor.Run(Request);

            m_logger.LogDebug(LogEventId.ScanBatchPostEnd, "Scan Batch processed: {0}.", Response.Success ? "Success" : "fail");

            if (!Response.Success)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpGet]
        public ScanBatchModel Get()
        {
            Scan s = new Scan()
            {
                Timestamp = 101,
                Kinematics = new Kinematics
                {
                    AccelerationX = 111,
                    AccelerationY = 222,
                    AccelerationZ = 333,
                    Altitude = 444,
                    Azimuth = 555,
                    Latitude = 666,
                    Longitude = 777,
                    Pitch = 888,
                    Roll = 999,
                    Timestamp = 3
                },
                BluetoothDevices = new List<BluetoothDevice>
                { 
                    new BluetoothDevice()
                  {
                    Address = "hw_address",
                    Name = "bluetooth Name",
                    Timestamp = 202,
                    Type = "IOT"
                  }
                },
                WifiDevices = new List<WifiDevice>
                {
                    new WifiDevice
                    {
                        BSSID = "bssid",
                        SSID = "ssid",
                        Capabilities = "caps",
                        Level = 4,
                        OperatorFriendlyName = "opname",
                        Timestamp = 404,
                        VenueName = "venue"
                    }
                }


            };

            List<Scan> scans = new List<Scan> (){s };
            return new ScanBatchModel { DeviceId = 4, Scans = scans};
        }
    }
}
