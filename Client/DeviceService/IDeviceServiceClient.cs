/***************************************************
    IDeviceServiceClient.cs

    Isaac Walker
****************************************************/


using System.Threading.Tasks;
using Web.Iot.Models.Device;

namespace Web.Iot.Client.DeviceService
{
    /// <summary>
    /// Client for the Device Service
    /// </summary>
    public interface IDeviceServiceClient : IServiceClient
    {
        /// <summary>
        /// Gets the count of the device
        /// </summary>
        /// <returns></returns>
        public Task<int> GetDeviceCountAsync();


        /// <summary>
        /// Registers a Device
        /// </summary>
        /// <returns></returns>
        public Task<int> RegisterDeviceAsync(DeviceModel device);
    }
}
