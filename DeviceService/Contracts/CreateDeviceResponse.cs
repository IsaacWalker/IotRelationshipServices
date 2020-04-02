/***************************************************
    CreateDeviceResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class CreateDeviceResponse : Response
    {
        public CreateDeviceResponse(bool Success) 
            : base(Success)
        {

        }
    }
}
