/***************************************************
    SettingServiceClient.cs

    Isaac Walker
****************************************************/


using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Iot.Models.Setting;

namespace Web.Iot.Client.SettingService
{
    /// <summary>
    /// Client for Setting Service
    /// </summary>
    public class SettingServiceClient : ISettingServiceClient
    {
        /// <summary>
        /// HttpClient Factory
        /// </summary>
        private readonly IHttpClientFactory m_httpClientFactory;


        /// <summary>
        /// Base URl for setting service
        /// </summary>
        private static readonly string s_baseUrl = "http://www.setting.iotrelationshipfyp.com";


        /// <summary>
        /// Get Setting Count URL
        /// </summary>
        private static readonly string s_getSettingCountUrl = s_baseUrl + "/api/setting/count";


        /// <summary>
        /// URL for Current Configuration
        /// </summary>
        private static readonly string s_currentConfigUrl = s_baseUrl + "/api/setting/current";


        /// <summary>
        /// Uri for settings service
        /// </summary>
        private static readonly string s_settingUri = s_baseUrl + "/api/setting";


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public SettingServiceClient(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// Gets count of the settings
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetSettingCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(s_getSettingCountUrl);
                bool parse_success = int.TryParse(await response.Content.ReadAsStringAsync(), out int result);

                if (response.IsSuccessStatusCode && parse_success)
                {
                    return result;
                }

                return -1;
            }
        }


        /// <summary>
        /// Gets the configuration with a certain Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ConfigurationModel> GetConfigurationAsync(int id)
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                string queryUrl = s_settingUri + string.Format("?id={0}", id);
                var response = await client.GetAsync(queryUrl);

                if (response.IsSuccessStatusCode)
                {

                    return JsonConvert.DeserializeObject<ConfigurationModel>(await response.Content.ReadAsStringAsync());
                }

                return null;
            }
        }


        /// <summary>
        /// Gets current configuration
        /// </summary>
        /// <returns></returns>
        public async Task<ConfigurationModel> GetCurrentConfigurationAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(s_currentConfigUrl);

                return JsonConvert.DeserializeObject<ConfigurationModel>(await response.Content.ReadAsStringAsync());
            }
        }


        /// <summary>
        /// Sets the current configuration 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Id of new, or existing </returns>
        public async Task<int> SetCurrentConfigurationAsync(ConfigurationModel model)
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(s_currentConfigUrl, content);

                var v = await response.Content.ReadAsStringAsync();
                return int.Parse(v);
            }
        }
    }
}
