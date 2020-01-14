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
        public readonly SettingsModel SettingsModel;


        public GetCurrentSettingsResponse(bool Success, SettingsModel settings) 
            : base(Success)
        {
            SettingsModel = settings;
        }
    }
}
