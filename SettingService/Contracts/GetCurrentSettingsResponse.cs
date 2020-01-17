/***************************************************
    GetCurrentSettingsResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Response for getting the current settings
    /// </summary>
    public class GetCurrentSettingsResponse : Response
    {
        /// <summary>
        /// The settings
        /// </summary>
        public readonly ConfigurationModel Configuration;


        public GetCurrentSettingsResponse(bool Success, ConfigurationModel configuration) 
            : base(Success)
        {
            Configuration = configuration;
        }
    }
}
