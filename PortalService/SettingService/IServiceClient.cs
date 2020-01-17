/***************************************************
    IServiceClient.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Web.Iot.Shared.Setting.Models;

namespace Web.Iot.PortalService.SettingService
{
    /// <summary>
    /// Client of the settings service 
    /// </summary>
    public interface IServiceClient
    {
        /// <summary>
        /// Gets the current configuration from the settings service
        /// </summary>
        /// <returns></returns>
        public Task<ConfigurationModel> GetCurrentConfigurationAsync();


        /// <summary>
        /// Gets the configuration wth a certain Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ConfigurationModel> GetConfigurationAsync(int id);
    }
}
