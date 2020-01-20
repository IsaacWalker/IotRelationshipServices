/***************************************************
    DeviceProcessor.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Web.Iot.DeviceService.Contracts;
using Web.Iot.DeviceService.Devices;

namespace Web.Iot.DeviceService.Processor
{
    public class DeviceProcessor : IDeviceProcessor
    {
        private readonly IServiceProvider m_serviceProvider;


        private readonly ILogger<DeviceProcessor> m_logger;


        public DeviceProcessor(IServiceProvider serviceProvider, ILogger<DeviceProcessor> logger)
        {
            m_serviceProvider = serviceProvider;
            m_logger = logger;
        }


        public Task<CreateDeviceResponse> Run(CreateDeviceRequest Request)
        {
            using (var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                Device device = new Device()
                {
                    MacAddress = Request.MacAddress,
                    BluetoothHardwareAddress = Request.BluetoothHardwareAddress,
                    Manufacturer = Request.Manufacturer,
                    Model = Request.DeviceModel
                };

                context.Devices.Add(device);

                return Task.FromResult(new CreateDeviceResponse(true, device.Id));
            }
        }
    }
}
