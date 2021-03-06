﻿/***************************************************
    MonitorController.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Client.SettingService;
using Web.Iot.PortalService.Models.ViewModels;

namespace Web.Iot.PortalService.Controllers
{
    /// <summary>
    /// Monitor Controller
    /// </summary>
    public class MonitorController : Controller
    {
        /// <summary>
        /// Setting Service Client
        /// </summary>
        private readonly ISettingServiceClient m_settingClient;


        /// <summary>
        /// Device Service Client
        /// </summary>
        private readonly IDeviceServiceClient m_deviceClient;


        /// <summary>
        /// Scan Service Client
        /// </summary>
        private readonly IScanServiceClient m_scanClient;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingClient"></param>
        /// <param name="deviceClient"></param>
        /// <param name="scanClient"></param>
        public MonitorController(
            ISettingServiceClient settingClient,
            IDeviceServiceClient deviceClient,
            IScanServiceClient scanClient
            )
        {
            m_settingClient = settingClient;
            m_deviceClient = deviceClient;
            m_scanClient = scanClient;
        }


        [HttpGet]
        [Route("monitor")]
        public async Task<ViewResult> Monitor()
        {
            MonitorModel model = new MonitorModel();

            bool settingPing = await m_settingClient.PingAsync();
            model.SettingServiceHealth = (settingPing) ? ServiceHealth.Healthy : ServiceHealth.UnHealthy;
            model.NumberOfSettings = await m_settingClient.GetSettingCountAsync();

            bool devicePing = await m_deviceClient.PingAsync();
            model.DeviceServiceHealth = (devicePing) ? ServiceHealth.Healthy : ServiceHealth.UnHealthy;
            model.NumberOfDevices = await m_deviceClient.GetDeviceCountAsync();

            bool scanPing = await m_scanClient.PingAsync();
            model.ScanServiceHealth = (scanPing) ? ServiceHealth.Healthy : ServiceHealth.UnHealthy;
            model.NumberOfScans = await m_scanClient.GetScanCountAsync();

            return View(model);
        }
    }
}
