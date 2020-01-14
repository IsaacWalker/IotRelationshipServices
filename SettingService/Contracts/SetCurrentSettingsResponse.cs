/***************************************************
    SetCurrentSettingsResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Response for Setting the current Entry 
    /// </summary>
    public class SetCurrentSettingsResponse : Response
    {
        /// <summary>
        /// Id of inserted entry
        /// </summary>
        public readonly int SettingsEntryId;


        public SetCurrentSettingsResponse(bool Success, int settingsEntryId) : base(Success)
        {
            SettingsEntryId = settingsEntryId;
        }
    }
}
