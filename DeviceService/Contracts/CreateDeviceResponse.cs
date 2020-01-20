/***************************************************
    CreateDeviceResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    public class CreateDeviceResponse : Response
    {
        /// <summary>
        /// Id of the Created Device
        /// </summary>
        public int Id { get; private set; }


        public CreateDeviceResponse(bool Success, int Id) 
            : base(Success)
        {
            this.Id = Id;
        }
    }
}
