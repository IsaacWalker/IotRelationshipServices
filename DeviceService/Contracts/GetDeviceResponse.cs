/***************************************************
    GetDeviceResponse.cs

    Isaac Walker
****************************************************/


using Web.Iot.DeviceService.Devices;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    /// <summary>
    /// Response for getting a device with a particular Id
    /// </summary>
    public class GetDeviceResponse : Response
    {
        /// <summary>
        /// Device 
        /// </summary>
        public readonly Device Device;


        public GetDeviceResponse(bool Success, Device device) : base(Success)
        {
            Device = device;
        }
    }
}
