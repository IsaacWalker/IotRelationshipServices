/***************************************************
    IDeviceProcessor.cs

    Isaac Walker
****************************************************/

using Web.Iot.DeviceService.Contracts;
using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Processor
{
    /// <summary>
    /// Processor for devices
    /// </summary>
    public interface IDeviceProcessor :
        IProcessor<CreateDeviceRequest, CreateDeviceResponse>
    {
    }
}
