using System;
using System.Collections.Generic;
using System.Linq;
/***************************************************
    ServiceClient.cs

    Isaac Walker
****************************************************/

using System.Net.Http;
using System.Threading.Tasks;
using Web.Iot.Shared.Setting.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Web.Iot.PortalService.SettingService
{
    /// <summary>
    /// Implementation for the settings service client
    /// </summary>
    public class ServiceClient : IServiceClient
    {
        /// <summary>
        /// Endpoint for accessing the current setting
        /// </summary>
        private static readonly string s_currentSettingUri = "http://www.setting.iotrelationshipfyp.com/api/setting/current";


        /// <summary>
        /// Uri for settings service
        /// </summary>
        private static readonly string s_settingUri = "http://www.setting.iotrelationshipfyp.com/api/setting";


        /// <summary>
        /// Httpclient Factory
        /// </summary>
        private readonly IHttpClientFactory m_httpClientFactory;



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ServiceClient(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
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

                if(response.IsSuccessStatusCode)
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
                var response = await client.GetAsync(s_currentSettingUri);

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
                var response = await client.PostAsync(s_currentSettingUri, content);

                var v = await response.Content.ReadAsStringAsync();
                return int.Parse(v);
            }
        }
    }
}
