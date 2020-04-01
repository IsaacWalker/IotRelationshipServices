using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security.SafetyNetCheck
{
    public class DeviceAttestationValidator : IDeviceAttestation
    {
        public Task<bool> IsValidAttestation(string attestationCypher, string apiKey, Guid nonce)
        {
            throw new NotImplementedException();
        }
    }
}
