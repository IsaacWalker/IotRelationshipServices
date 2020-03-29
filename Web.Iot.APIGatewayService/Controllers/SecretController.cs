using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Iot.Models.Secret;

namespace Web.Iot.APIGatewayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : ControllerBase
    {
        /// <summary>
        /// Gets a nonce
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNonce()
        {
            return Ok();
        }


        /// <summary>
        /// Gets a time sensitive Jwt that may or may not be valid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetToken([FromBody] TokenRequestModel model)
        {
            return Ok();
        }
    }
}