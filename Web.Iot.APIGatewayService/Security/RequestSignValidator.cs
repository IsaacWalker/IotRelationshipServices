using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security
{
    /// <summary>
    /// Tests if the sign is valid
    /// </summary>
    public class RequestSignValidator : IRequestSignValidator
    {
        public bool Run(string signatureString, string keyString, SignValidatorMessage messageParams)
        {
            byte[] message = Encoding.ASCII.GetBytes(messageParams.Route + messageParams.Token);
            byte[] key = Encoding.ASCII.GetBytes(keyString);
            byte[] requestSignature = Encoding.ASCII.GetBytes(signatureString);

            HMACSHA256 hmac = new HMACSHA256(key);
            byte[] validSignature =  hmac.ComputeHash(message);
            return requestSignature.SequenceEqual(validSignature);
        }
    }
}
