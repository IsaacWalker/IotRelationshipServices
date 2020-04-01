using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Iot.APIGatewayService.Security;
using Web.Iot.Models.Secret;

namespace Web.Iot.APIGatewayService.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class SecretController : ControllerBase
    {
        private readonly IJwtTokenService m_tokenService;


        private readonly INonceStore m_nonceStore;


        private readonly IDeviceAttestation m_attestationService;


        private readonly IConfiguration m_configuration;


        public SecretController(
            IJwtTokenService tokenService, 
            INonceStore nonceStore,
            IDeviceAttestation deviceAttestation,
            IConfiguration configuration
            )
        {
            m_tokenService = tokenService;
            m_nonceStore = nonceStore;
            m_attestationService = deviceAttestation;
            m_configuration = configuration;
            jwtSecret = configuration.GetValue<string>("JwtSettings:Secret");
            JwtAudience = configuration.GetValue<string>("JwtSettings:Audience");
            JwtIssuer = configuration.GetValue<string>("JwtSettings:Issuer");
        }


        /// <summary>
        /// Gets a nonce
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("secret/nonce")]
        public IActionResult GetNonce()
        {
            return Ok(m_nonceStore.CreateNewAsync());
        }


        /// <summary>
        /// Gets a time sensitive Jwt that may or may not be valid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("secret/token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            Guid nonce = model.Nonce;
            if(m_nonceStore.Exists(nonce))
            {
                var deviceModel = model.DeviceModel;
                if (await m_attestationService.IsValidAttestation(model.AttestationCypher, attestSecret, nonce))
                {
                    // Everything is valid

                    // Creating the token
                    TokenParams tokenParams = new TokenParams(jwtSecret, JwtIssuer, JwtAudience);
                    var token = m_tokenService.Generate(deviceModel, tokenParams);
                    return Ok(token);
                }
            }

            return Ok(m_tokenService.GenerateFakeToken());
        }


        private readonly string JwtIssuer;


        private readonly string JwtAudience;


        private readonly string jwtSecret;


        private readonly string attestSecret;
    }
}