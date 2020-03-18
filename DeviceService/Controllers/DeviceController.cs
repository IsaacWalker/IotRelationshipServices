/***************************************************
    DeviceController.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.DeviceService.Contracts;
using Web.Iot.DeviceService.Processor;
using Web.Iot.Models.Device;
using Web.Iot.Models.GDPR;

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
                deviceModel.Model,
                DateTime.Now);

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
        [Route("api/[controller]/subjectData")]
        public async Task<IActionResult> GetSubjectlData(int deviceId)
        {
            var response = await m_processor.Run(new GetDeviceSARequest(deviceId));

            if(response.Success)
            {
                var device = response.DeviceModel;

                SubjectDataModel dataModel = new SubjectDataModel()
                {
                    Name = "Device Data",
                    Data = new Dictionary<string,string>()
                    {
                        {nameof(device.BluetoothName), device.BluetoothName },
                        {nameof(device.MacAddress), device.MacAddress },
                        {nameof(device.Manufacturer), device.Manufacturer },
                        {nameof(device.Model), device.Model }
                    },
                    DateOfCollection = response.DeviceModel.DateOfCreation,
                    DateOfDeletion = response.DeviceModel.DateOfCreation + TimeSpan.FromDays(30.0),
                    Categories = s_devicePersonalDataCategories
                };

                return Ok(dataModel);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("api/[controller]/subjectData")]
        public async Task<IActionResult> DeleteSubjectData(int deviceId)
        {
            var response = await m_processor.Run(new EraseSubjectDataRequest(deviceId));
            return response.Success ? Ok() : BadRequest() as IActionResult;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Ping()
        {
            return Ok();
        }


        private static readonly IList<string> s_devicePersonalDataCategories = new List<string> 
        { 
            "Personally Identifiable Information"
        };
    }
}
