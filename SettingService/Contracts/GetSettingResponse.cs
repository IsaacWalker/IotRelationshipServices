/***************************************************
    GetSettingResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Models.Setting;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Response for getting a setting 
    /// </summary>
    public class GetSettingResponse : Response
    {
        public readonly ConfigurationModel Configuration;


        public GetSettingResponse(bool Success, ConfigurationModel configuration) : base(Success)
        {
            Configuration = configuration;
        }
    }
}
