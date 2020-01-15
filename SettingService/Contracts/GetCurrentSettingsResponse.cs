/***************************************************
    GetCurrentSettingsResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.SettingService.Models;
using Web.Iot.Shared.Message;

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
