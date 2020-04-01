using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Models.Device;

namespace Web.Iot.APIGatewayService.Security
{
    /// <summary>
    /// Parameters to token parameter
    /// </summary>
    public class TokenParams
    {
        /// <summary>
        /// The Secret used in creating the parameter
        /// </summary>
        public readonly string Secret;


        /// <summary>
        /// The Issuer of the Token
        /// </summary>
        public readonly string Issuer;


        /// <summary>
        /// The Audience of the Jwt
        /// </summary>
        public readonly string Audience;


        public TokenParams(
            string secret,
            string issuer,
            string audience)
        {
            Secret = secret;
            Issuer = issuer;
            Audience = audience;
        }
    }


    /// <summary>
    /// Generates a jwt token
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Generates a token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tokenParams"></param>
        /// <returns></returns>
        public string Generate(DeviceModel deviceModel, TokenParams tokenParams);


        /// <summary>
        /// Validates a token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tokenParams"></param>
        /// <returns></returns>
        public bool Validate(string token, TokenParams tokenParams);


        /// <summary>
        /// Generates a fake token
        /// </summary>
        /// <returns></returns>
        public string GenerateFakeToken();
    }
}
