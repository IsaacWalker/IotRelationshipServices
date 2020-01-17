/***************************************************
    HomeModel.cs

    Isaac Walker
****************************************************/


using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.PortalService.Models.ViewModels
{
    /// <summary>
    /// Model for the home screen
    /// </summary>
    public class HomeModel
    {
        /// <summary>
        /// Did the setting exist
        /// </summary>
        public bool SettingExists = false;


        /// <summary>
        /// The configuration
        /// </summary>
        public ConfigurationModel Configuration { get; set; }
    }
}
