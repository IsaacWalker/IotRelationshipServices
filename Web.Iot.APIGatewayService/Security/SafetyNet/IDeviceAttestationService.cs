using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security.SafetyNetCheck
{
    /// <summary>
    /// Google Play Attestation response validator
    /// </summary>
    public interface IDeviceAttestation
    {
        public Task<bool> IsValidAttestation(string attestationCypher, string apiKey, Guid nonce);
    }
}
