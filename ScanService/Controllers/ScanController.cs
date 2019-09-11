/***************************************************
    ScanController.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.ScanService.Models;
using Web.Iot.ScanService.MongoDB;
using Web.Iot.ScanService.MongoDB.Data;

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

        [HttpGet]
        public IActionResult Get()
        {
            var mod = new ScanBatchModel()
            {
                DeviceId = 0,
                Scans = new List<ScanModel>()
                {
                    new ScanModel()
                    {
                        IsBluetoothEnabled = true,
                        IsKinematicsEnabled = true,
                        IsWifiEnabled = true,
                        DateTime = DateTime.Now,
                        WifiDevices = new List<WifiDeviceModel>()
                        {
                            new WifiDeviceModel()
                            {
                                BSSID = "BSSID1",
                                SSID = "SSID1",
                                ChannelWidth = 123,
                                Frequency = 12f,
                                Level = 4,
                                VenueName = "Dublin Airport"
                            }
                        },
                        BluetoothDevices = new List<BluetoothDeviceModel>()
                        {
                            new BluetoothDeviceModel()
                            {
                                MAC = "Mac1",
                                Name = "BluetoothName"
                            }
                        },
                        Kinematics = new KinematicsModel()
                        {
                            Acceleration = new LinearAccelerationModel(){X=23,Y=23,Z=3 },
                            Location = new GPSLocationModel {Latitude=23, Longitude=23}
                        }                                         
                    }
                }
            };

            return new JsonResult(mod);
        }

        /// <summary>
        /// Batch Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScanBatchModel ScanBatch)
        {
            m_logger.LogDebug(LogEventId.ScanBatchPostStart, string.Format("Scans Received: From {0}, Number {1}",
                ScanBatch.DeviceId, ScanBatch.Scans.Count));

            LogScanRequest Request = new LogScanRequest(ScanBatch.Scans.Select(S => ConvertScanModel(ScanBatch.DeviceId, S)).ToList());
            LogScanResponse Response = await m_processor.Run(Request);

            m_logger.LogDebug(LogEventId.ScanBatchPostEnd, "Scan Batch processed: {0}.", Response.Success ? "Success" : "fail");

            if (!Response.Success)
            {
                return BadRequest();
            }

            return Ok();
        }


        private Scan ConvertScanModel(long deviceId, ScanModel scanModel)
        {
            return new Scan()
            {
                DeviceId = deviceId,
                IsBluetoothEnabled = scanModel.IsBluetoothEnabled,
                IsKinematicsEnabled = scanModel.IsKinematicsEnabled,
                IsWifiEnabled = scanModel.IsWifiEnabled,
                DateTime = scanModel.DateTime,
                Kinematics = new Kinematics()
                {
                    Acceleration = new LinearAcceleration
                    {
                        X = scanModel.Kinematics.Acceleration.X,
                        Y = scanModel.Kinematics.Acceleration.Y,
                        Z = scanModel.Kinematics.Acceleration.Z
                    },
                    Location = new GPSLocation
                    {
                        Latitude = scanModel.Kinematics.Location.Latitude,
                        Longitude = scanModel.Kinematics.Location.Longitude
                    }
                },
                BluetoothDevices = scanModel.BluetoothDevices.Select(B =>
                new BluetoothDevice()
                {
                    MAC = B.MAC,
                    Name = B.Name
                }).ToList(),
                WifiDevices = scanModel.WifiDevices.Select(W =>
                new WifiDevice()
                {
                    BSSID = W.BSSID,
                    ChannelWidth = W.ChannelWidth,
                    Frequency = W.Frequency,
                    Level = W.Level,
                    SSID = W.SSID,
                    VenueName = W.VenueName
                }).ToList()
            };
        }
    }
}
