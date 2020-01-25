/***************************************************
    ScanServiceClient.cs

    Isaac Walker
****************************************************/


using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Iot.Client.ScanService
{
    /// <summary>
    /// Client for the Scan Service
    /// </summary>
    public class ScanServiceClient : ServiceClientBase, IScanServiceClient
    {

        protected readonly Uri m_getScanCountUri;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ScanServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory,
            new Uri("http://www.scan.iotrelationshipfyp.com"))
        {
            m_getScanCountUri = new Uri(m_baseURI.AbsoluteUri + "api/scan/count");
        }


        /// <summary>
        /// Gets the count of the scans
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetScanCountAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(m_getScanCountUri);
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
