/***************************************************
    SetCurrentSettingsRequest.cs

    Isaac Walker
****************************************************/

using Web.Iot.SettingService.Models;
using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Request for setting current entry
    /// </summary>
    public class SetCurrentSettingsRequest : Request
    {
        /// <summary>
        /// The settings model
        /// </summary>
        public readonly SettingsModel SettingsModel;


        public SetCurrentSettingsRequest(SettingsModel settingsModel)
        {
            SettingsModel = settingsModel;
        }
    }
}
