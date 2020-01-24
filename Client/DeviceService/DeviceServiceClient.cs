/***************************************************
    DeviceServiceClient.cs

    Isaac Walker
****************************************************/


using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Iot.Client.DeviceService
{
    /// <summary>
    /// Client for the Device Service
    /// </summary>
    public class DeviceServiceClient : IDeviceServiceClient
    {
        /// <summary>
        /// HttpClient Factory
        /// </summary>
        private readonly IHttpClientFactory m_httpClientFactory;


        /// <summary>
        /// Device Service Root Url
        /// </summary>
        private static readonly string s_deviceServiceRoot = "http://device.iotrelationshipfyp.com";


        /// <summary>
        /// Get Device Count Url
        /// </summary>
        private static readonly string s_getDeviceCountUrl = s_deviceServiceRoot + "/api/device/count";


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public DeviceServiceClient(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// Gets the count of devices
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetDevicesCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(s_getDeviceCountUrl);
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
