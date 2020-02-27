/***************************************************
    ScanServiceClient.cs

    Isaac Walker
****************************************************/


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Iot.Models.MongoDB;
using Web.Iot.ScanService.Models;

namespace Web.Iot.Client.ScanService
{
    /// <summary>
    /// Client for the Scan Service
    /// </summary>
    public class ScanServiceClient : ServiceClientBase, IScanServiceClient
    {

        protected readonly Uri m_getScanCountUri;


        protected readonly Uri m_scanUrl;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public ScanServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory,
            new Uri("http://www.scan.iotrelationshipfyp.com"))
        {
            m_getScanCountUri = new Uri(m_baseURI.AbsoluteUri + "api/scan/count");
            m_scanUrl = new Uri(m_baseURI.AbsoluteUri + "api/scan");
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


        /// <summary>
        /// Inserts a Scan batch
        /// </summary>
        /// <param name="scanBatch"></param>
        /// <returns></returns>
        public async Task<bool> InsertScanBatchAsync(ScanBatchModel scanBatch)
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(scanBatch));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(m_scanUrl, content);
                bool parse_success = int.TryParse(await response.Content.ReadAsStringAsync(), out int result);

                return response.IsSuccessStatusCode;
            }
        }


        public static IList<ScanBatchModel> CreateScanBatchModels(IList<ScanModel> scanModels, int batchSize)
        {
            List<ScanBatchModel> scanBatchModels = new List<ScanBatchModel>();
            var groups = scanModels.GroupBy(S => S.DeviceId);

            foreach (var g in groups)
            {
                for (int i = 0; i < g.Count(); i += batchSize)
                {
                    scanBatchModels.Add(new ScanBatchModel()
                    {
                        DeviceId = g.Key,
                        Scans = g.ToList().GetRange(i, Math.Min(batchSize, g.Count() - i))
                    });              
                }
            }

            return scanBatchModels;
            
        }
    }
}
