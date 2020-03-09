using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;

namespace Web.Iot.GDPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectAccessRequestController : ControllerBase
    {
        private readonly IDeviceServiceClient m_deviceServiceClient;


        private readonly IScanServiceClient m_scanServiceClient;


        public SubjectAccessRequestController(IDeviceServiceClient deviceServiceClient, IScanServiceClient scanServiceClient)
        {
            m_deviceServiceClient = deviceServiceClient;
            m_scanServiceClient = scanServiceClient;
        }

        public async Task<IActionResult> Get(int deviceId)
        {
            /// Get Device Data
            var deviceData = await m_deviceServiceClient.GetDevicePersonalData(deviceId);

            /// Get Device Scans
            var scanData = await m_scanServiceClient.GetScanPersonalData(deviceId);
            return Ok();
        }
    }
}