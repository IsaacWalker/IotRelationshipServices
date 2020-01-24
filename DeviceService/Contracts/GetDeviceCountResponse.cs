/***************************************************
    GetDeviceCountResponse.cs

    Isaac Walker
****************************************************/


using Web.Iot.Shared.Message;

namespace Web.Iot.DeviceService.Contracts
{
    /// <summary>
    /// Response for getting the count of the devices
    /// </summary>
    public class GetDeviceCountResponse : Response
    {
        /// <summary>
        /// Count of devices
        /// </summary>
        public readonly int Count;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Success"></param>
        /// <param name="Count"></param>
        public GetDeviceCountResponse(bool Success, int Count) : base(Success)
        {
            this.Count = Count;
        }
    }
}
