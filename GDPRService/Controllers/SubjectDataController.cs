using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Models.GDPR;

namespace Web.Iot.GDPRService.Controllers
{
    [ApiController]
    public class SubjectDataController : ControllerBase
    {
        private readonly IDeviceServiceClient m_deviceServiceClient;


        private readonly IScanServiceClient m_scanServiceClient;


        public SubjectDataController(IDeviceServiceClient deviceServiceClient, IScanServiceClient scanServiceClient)
        {
            m_deviceServiceClient = deviceServiceClient;
            m_scanServiceClient = scanServiceClient;
        }


        /// <summary>
        /// Subject Access Request
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get([FromQuery] int deviceId)
        {
            var model = await GetSubjectData(deviceId);
            return Ok(model);
        }


        /// <summary>
        /// Subject Erasure Request
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]")]
        public async Task<IActionResult> Delete([FromQuery] int deviceId)
        {
            var scanSuccess = await m_scanServiceClient.EraseSubjectData(deviceId);
            
            if(scanSuccess)
            {
                var deviceSuccess = await m_deviceServiceClient.EraseSubjectData(deviceId);
                
                if(deviceSuccess)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }


        [HttpGet("api/[controller]/portable")]
        public async Task<IActionResult> GetPortable([FromQuery] int deviceId)
        {
            var model = await GetSubjectData(deviceId);
            byte[] bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(model));
            return File(bytes, "application/json");
        }


        private async Task<SubjectAccessRequestModel> GetSubjectData(int deviceId)
        {
            /// Get Device Data
            var deviceData = await m_deviceServiceClient.GetDeviceSubjectData(deviceId);

            /// Get Device Scans
            var scanData = await m_scanServiceClient.GetScanSubjectData(deviceId);

            SubjectAccessRequestModel model = new SubjectAccessRequestModel()
            {
                ScanSubjectData = scanData,
                DeviceSubjectData = deviceData,
                DateTimeOfRequest = DateTime.Now
            };

            return model;
        }
    }
}