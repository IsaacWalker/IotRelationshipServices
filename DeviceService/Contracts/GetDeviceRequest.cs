/***************************************************
    GetDeviceRequest.cs

    Isaac Walker
****************************************************/

using System;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    /// <summary>
    /// Request for getting the device with a specified device
    /// </summary>
    public class GetDeviceRequest : Request
    {
        /// <summary>
        /// Id of the device
        /// </summary>
        public readonly Guid Id;


        public GetDeviceRequest(Guid id)
        {
            Id = id;
        }
    }
}
