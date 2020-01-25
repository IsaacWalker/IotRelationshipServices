using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web.Iot.Client
{
    public abstract class ServiceClientBase : IServiceClient
    {
        /// <summary>
        /// HttpClient Factory
        /// </summary>
        protected readonly IHttpClientFactory m_httpClientFactory;



        protected readonly Uri m_baseURI;

        
        public ServiceClientBase(IHttpClientFactory httpClientFactory, Uri baseUri)
        {
            m_httpClientFactory = httpClientFactory;
            m_baseURI = baseUri;
        }


        /// <summary>
        /// Pings the endpoint
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> PingAsync()
        {
            using (HttpClient client = m_httpClientFactory.CreateClient())
            {
                var response = await client.GetAsync(m_baseURI);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
