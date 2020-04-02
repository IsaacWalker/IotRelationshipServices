/***************************************************
    DeviceServiceClient.cs

    Isaac Walker
****************************************************/


using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Iot.Models.Device;
using Web.Iot.Models.GDPR;

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
        /// Device Url
        /// </summary>
        protected readonly Uri m_deviceUrl;


        /// <summary>
        /// Gets the personal data
        /// </summary>
        protected readonly Uri m_subjectDataUrl;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public DeviceServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory,
            new Uri("http://www.device.iotrelationshipfyp.com"))
        {
            m_getDeviceCountUrl = new Uri(m_baseURI.AbsoluteUri + "api/device/count");
            m_deviceUrl = new Uri(m_baseURI.AbsoluteUri + "api/device");
            m_subjectDataUrl = new Uri(m_baseURI.AbsoluteUri + "api/device/subjectData");
        }


        /// <summary>
        /// Deletes the subject data for an Erasure Request
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<bool> EraseSubjectData(Guid deviceId)
        {
            UriBuilder builder = new UriBuilder(m_subjectDataUrl);
            builder.Query = string.Format("{0}={1}", nameof(deviceId), deviceId);

            using (var client = m_httpClientFactory.CreateClient())
            {
                var response = await client.DeleteAsync(builder.Uri);
                return response.IsSuccessStatusCode;
            }
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


        /// <summary>
        /// Gets the personal data of an individual related to a device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<SubjectDataModel> GetDeviceSubjectData(Guid deviceId)
        {
            UriBuilder builder = new UriBuilder(m_subjectDataUrl);
            builder.Query = string.Format("{0}={1}", nameof(deviceId), deviceId);

            using(var client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(builder.Uri);

                if(response.IsSuccessStatusCode)
                {
                    var personalDataModel = JsonConvert.DeserializeObject<SubjectDataModel>(await response.Content.ReadAsStringAsync());
                    return personalDataModel;
                }
            }

            return default;
        }


        /// <summary>
        /// Registers a device
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RegisterDeviceAsync(DeviceModel device)
        {
            using(HttpClient client = m_httpClientFactory.CreateClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(device));
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(m_deviceUrl,content);

                return response.IsSuccessStatusCode;             
            }
        }
    }
}
