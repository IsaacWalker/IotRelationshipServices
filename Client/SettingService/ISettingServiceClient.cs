/***************************************************
    ISettingServiceClient.cs

    Isaac Walker
****************************************************/


using System.Threading.Tasks;
using Web.Iot.Models.Setting;

namespace Web.Iot.Client.SettingService
{
    /// <summary>
    /// Client for the Setting Service
    /// </summary>
    public interface ISettingServiceClient : IServiceClient
    {
        /// <summary>
        /// Gets the count of the settings
        /// </summary>
        /// <returns></returns>
        public Task<int> GetSettingCountAsync();


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


        /// <summary>
        /// Sets the current configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<int> SetCurrentConfigurationAsync(ConfigurationModel model);
    }
}
