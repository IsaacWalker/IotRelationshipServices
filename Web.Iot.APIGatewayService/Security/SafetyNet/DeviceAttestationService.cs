using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security.SafetyNetCheck
{
    public class DeviceAttestationService : IDeviceAttestation
    {

        private static readonly string ServiceUrl = "https://www.googleapis.com/androidcheck/v1/attestations/verify";


        private readonly IHttpClientFactory m_httpClientFactory;


        public DeviceAttestationService(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
        }


        public async Task<bool> IsValidAttestation(string attestation, string apiKey, Guid nonce)
        {
            UriBuilder builder = new UriBuilder(ServiceUrl)
            {
                Query = string.Format("key={0}", apiKey)
            };

            using (var client = m_httpClientFactory.CreateClient())
            {
                var signedAttestJson = JsonConvert.SerializeObject(new { signedAttestation = attestation });
                HttpContent content = new StringContent( signedAttestJson, Encoding.Default, "application/json");
                var result = await client.PostAsync(builder.Uri, content);

                if(result.IsSuccessStatusCode)
                {
                    var attestationResult = JsonConvert.DeserializeObject<AttestationResult>
                        (await result.Content.ReadAsStringAsync());

                    return attestationResult == default ? false : attestationResult.IsValidSignature;
                }
            }

            return false;
        }

  
        public sealed class AttestationResult
        { 
            public bool IsValidSignature { get; set; }
        }
    }
}
