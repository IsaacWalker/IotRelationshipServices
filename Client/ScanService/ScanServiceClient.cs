/***************************************************
    ScanServiceClient.cs

    Isaac Walker
****************************************************/


using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Iot.Client.ScanService
{
    /// <summary>
    /// Client for the Scan Service
    /// </summary>
    public class ScanServiceClient : IScanServiceClient
    {
        /// <summary>
        /// HttpClient Factory
        /// </summary>
        private readonly IHttpClientFactory m_httpClientFactory;


        /// <summary>
        /// Scan Service Base Url
        /// </summary>
        private static readonly string s_baseUrl = "http://www.scan.iotrelationshipfyp.com";


        /// <summary>
        /// Get Scan Count Url
        /// </summary>
        private static readonly string s_getScanCountUrl = s_baseUrl + "/api/scan/count";


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ScanServiceClient(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// Gets the count of the scans
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetScanCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(s_getScanCountUrl);
                bool parse_success = int.TryParse(await response.Content.ReadAsStringAsync(), out int result);

                if (response.IsSuccessStatusCode && parse_success)
                {
                    return result;
                }

                return -1;
            }
        }
    }
}
