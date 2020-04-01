using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security
{
    /// <summary>
    /// The message component of a signed request
    /// </summary>
    public readonly ref struct SignValidatorMessage
    {
        /// <summary>
        /// The route of the HttpRequest
        /// </summary>
        public readonly string Route;


        /// <summary>
        /// The Jwt Token used
        /// </summary>
        public readonly string Token;


        public SignValidatorMessage(string route, string token)
        {
            Route = route;
            Token = token;
        }
    }


    /// <summary>
    /// Checks if signed request is valid
    /// </summary>
    public interface IRequestSignValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signatureString"></param>
        /// <param name="keyString"></param>
        /// <param name="messageParams"></param>
        /// <returns></returns>
        public bool Run(string signatureString, string keyString, SignValidatorMessage messageParams);
    }
}
