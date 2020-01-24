/***************************************************
    IDeviceServiceClient.cs

    Isaac Walker
****************************************************/


using System.Threading.Tasks;

namespace Web.Iot.Client.DeviceService
{
    /// <summary>
    /// Client for the Device Service
    /// </summary>
    public interface IDeviceServiceClient
    {
        /// <summary>
        /// Gets the count of the device
        /// </summary>
        /// <returns></returns>
        public Task<int> GetDeviceCountAsync();
    }
}
