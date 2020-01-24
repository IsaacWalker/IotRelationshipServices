/***************************************************
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

            int num_settings = await m_settingClient.GetSettingCountAsync();
            int num_scans = await m_deviceClient.GetDeviceCountAsync();

            return View(model);
        }
    }
}
