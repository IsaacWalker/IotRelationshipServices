/***************************************************
    GetSettingCountReseponse.cs

    Isaac Walker
****************************************************/


using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Request for getting the count of the settings
    /// </summary>
    public class GetSettingCountResponse : Response
    {
        public readonly int Number;


        public GetSettingCountResponse(bool Success, int Number) : base(Success)
        {
            this.Number = Number;
        }
    }
}
