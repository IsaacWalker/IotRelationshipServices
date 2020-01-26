/***************************************************
    DeviceServiceClient.cs

    Isaac Walker
****************************************************/


using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Iot.Client.DeviceService
{
    /// <summary>
    /// Client for the Device Service
    /// </summary>
    public class DeviceServiceClient : ServiceClientBase, IDeviceServiceClient
    {
        /// <summary>
        /// Get Device Count Url
        /// </summary>
        protected readonly Uri m_getDeviceCountUrl;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public DeviceServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory,
            new Uri("http://www.device.iotrelationshipfyp.com"))
        {
            m_getDeviceCountUrl = new Uri(m_baseURI.AbsoluteUri + "api/device/count");
        }


        /// <summary>
        /// Gets the count of devices
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetDeviceCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(m_getDeviceCountUrl);
                bool parse_success = int.TryParse(await response.Content.ReadAsStringAsync(), out int result);
                
                if(response.IsSuccessStatusCode && parse_success)
                {
                    return result;
                }

                return -1;
            }
        }
    }
}
