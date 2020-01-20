/***************************************************
    DeviceController.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.DeviceService.Contracts;
using Web.Iot.DeviceService.Models;
using Web.Iot.DeviceService.Processor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Iot.DeviceService.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceProcessor m_processor;


        private readonly ILogger<DeviceController> m_logger;


        public DeviceController(IDeviceProcessor processor, ILogger<DeviceController> logger)
        {
            m_processor = processor;
            m_logger = logger;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post(DeviceModel deviceModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            CreateDeviceRequest request = new CreateDeviceRequest(
                deviceModel.MacAddress,
                deviceModel.BluetoothHardwareAddress,
                deviceModel.Manufacturer,
                deviceModel.Model);

            var response = await m_processor.Run(request);

            if(!response.Success)
            {
                return BadRequest();
            }

            return Ok(response.Id);
                
        }
    }
}
