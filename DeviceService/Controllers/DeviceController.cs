/***************************************************
    DeviceController.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.DeviceService.Contracts;
using Web.Iot.DeviceService.Processor;
using Web.Iot.Models.Device;

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


        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] DeviceModel deviceModel)
        {
            m_logger.LogDebug(LogEventId.CreateDeviceStart, "Starting request to create device");

            if(!ModelState.IsValid)
            {
                m_logger.LogDebug(LogEventId.CreateDeviceEnd, "Ending request to create device failed with invalid model");

                return BadRequest();
            }

            CreateDeviceRequest request = new CreateDeviceRequest(
                deviceModel.MacAddress,
                deviceModel.BluetoothName,
                deviceModel.Manufacturer,
                deviceModel.Model);

            var response = await m_processor.Run(request);

            if(!response.Success)
            {
                m_logger.LogDebug(LogEventId.CreateDeviceEnd, "Ending request to create device failed with bad request");

                return BadRequest();
            }

            m_logger.LogDebug(LogEventId.CreateDeviceEnd, string.Format("Ending request to create device success with Id {0}", response.Id));

            return Ok(response.Id);
                
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            m_logger.LogDebug(LogEventId.GetDeviceStart, string.Format("Starting request to get device with id {0}", id));

            var request = new GetDeviceRequest(id);

            var response = await m_processor.Run(request);
            
            if(!response.Success)
            {
                m_logger.LogDebug(LogEventId.GetDeviceEnd, string.Format("Ending request to get device, No device found with Id {0}", id));

                return NotFound();
            }
           
            DeviceModel model = new DeviceModel
            {
                BluetoothName = response.Device.BluetoothName,
                MacAddress = response.Device.MacAddress,
                Manufacturer = response.Device.Manufacturer,
                Model = response.Device.Model
            };

            m_logger.LogDebug(LogEventId.GetDeviceEnd, string.Format("Ending request to get device, Device found with Id {0}", id));

            return Ok(model);
        }


        [HttpGet]
        [Route("api/[controller]/count")]
        public async Task<IActionResult> GetDeviceCount()
        {
            var response = await m_processor.Run(new GetDeviceCountRequest());

            return Ok(response.Count);
        }


        [HttpGet]
        [Route("")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
