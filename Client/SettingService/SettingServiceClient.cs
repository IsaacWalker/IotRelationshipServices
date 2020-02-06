/***************************************************
    SettingServiceClient.cs

    Isaac Walker
****************************************************/


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Iot.Models.Setting;

namespace Web.Iot.Client.SettingService
{
    /// <summary>
    /// Client for Setting Service
    /// </summary>
    public class SettingServiceClient : ServiceClientBase, ISettingServiceClient
    {
        /// <summary>
        /// Get Setting Count URL
        /// 
        /// </summary>
        private readonly Uri m_getSettingCountUrl;


        /// <summary>
        /// URL for Current Configuration
        /// </summary>
        private readonly Uri m_currentConfigUrl;


        /// <summary>
        /// Uri for settings service
        /// </summary>
        private readonly Uri m_settingUri;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public SettingServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory,
            new Uri("http://www.setting.iotrelationshipfyp.com"))
        {
            m_getSettingCountUrl = new Uri(m_baseURI.AbsoluteUri + "api/setting/count");
            m_currentConfigUrl = new Uri(m_baseURI.AbsoluteUri + "api/setting/current");
            m_settingUri = new Uri(m_baseURI.AbsoluteUri + "api/setting");
        }


        /// <summary>
        /// Gets count of the settings
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetSettingCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(m_getSettingCountUrl);
                string content = await response.Content.ReadAsStringAsync();
                bool parse_success = int.TryParse(content, out int result);

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
                string queryUrl = m_settingUri + string.Format("?id={0}", id);
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
                var response = await client.GetAsync(m_currentConfigUrl);

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
                var response = await client.PostAsync(m_currentConfigUrl, content);

                var v = await response.Content.ReadAsStringAsync();
                return int.Parse(v);
            }
        }


        /// <summary>
        /// Posts a setting to the /setting endpoint, creating it if it doesn't exist already and returns the id
        /// </summary>
        /// <param name="settingModels"></param>
        /// <returns></returns>
        public async Task<int> RegisterConfigurationAsync(List<SettingModel> settingModels)
        {
            using(HttpClient client = m_httpClientFactory.CreateClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(settingModels));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(m_settingUri, content);

                var v = await response.Content.ReadAsStringAsync();
                return int.Parse(v);
            }
        }
    }
}
