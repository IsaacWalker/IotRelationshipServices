/***************************************************
    DeviceProcessor.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.DeviceService.Contracts;
using Web.Iot.DeviceService.Devices;
using Web.Iot.Models.Device;

namespace Web.Iot.DeviceService.Processor
{
    public class DeviceProcessor : IDeviceProcessor
    {
        private readonly IServiceProvider m_serviceProvider;


        private readonly ILogger<DeviceProcessor> m_logger;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        public DeviceProcessor(IServiceProvider serviceProvider, ILogger<DeviceProcessor> logger)
        {
            m_serviceProvider = serviceProvider;
            m_logger = logger;
        }


        /// <summary>
        /// Attempts to create the device in the database, returning the new Id
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<CreateDeviceResponse> Run(CreateDeviceRequest Request)
        {
            using (var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                // Is device present?
                var device = context.Devices
                    .Where(D => D.MacAddress == Request.MacAddress)
                    .FirstOrDefault();

                if(device == default)
                {

                    device = new Device()
                    {
                        MacAddress = Request.MacAddress,
                        BluetoothName = Request.BluetoothName,
                        Manufacturer = Request.Manufacturer,
                        Model = Request.DeviceModel
                    };

                    context.Devices.Add(device);
                    context.SaveChanges();
                }

                return Task.FromResult(new CreateDeviceResponse(true, device.Id));
            }
        }


        /// <summary>
        /// Attempts to get the device with an Id from the database
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<GetDeviceResponse> Run(GetDeviceRequest Request)
        {
            using(var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                var device = context.Devices.Find(Request.Id);

                return Task.FromResult(new GetDeviceResponse(device != default, device));
            }
        }


        /// <summary>
        /// Gets the count of devices
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public Task<GetDeviceCountResponse> Run(GetDeviceCountRequest Request)
        {
            using(var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                int count = context.Devices.Count();

                return Task.FromResult(new GetDeviceCountResponse(true, count));
            }
        }


        /// <summary>
        /// Gets the Subject Access Request of the device
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public async Task<GetDeviceSAResponse> Run(GetDeviceSARequest Request)
        {
            using(var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                var device = await context.Devices.FindAsync(Request.DeviceId);

                if (device != default)
                {
                    var response = new GetDeviceSAResponse(device, true);

                    return response;
                }            
            }
            
            return new GetDeviceSAResponse(default, false);
        }

        public async Task<EraseSubjectDataResponse> Run(EraseSubjectDataRequest Request)
        {
            using(var scope = m_serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DeviceContext>();

                var device = await context.Devices.FindAsync(Request.DeviceId);
                var remove = context.Devices.Remove(device);
                await context.SaveChangesAsync();

                return new EraseSubjectDataResponse(remove.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
            }
        }
    }
}
