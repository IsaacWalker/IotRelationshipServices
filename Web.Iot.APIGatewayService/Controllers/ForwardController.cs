using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Iot.APIGatewayService.Security;
using Web.Iot.Client.DeviceService;

namespace Web.Iot.APIGatewayService.Controllers
{
    [Authorize]
    [ApiController]
    public class ForwardController : ControllerBase
    {
        private readonly IDeviceServiceClient m_deviceServiceClient;


        public ForwardController(
            IDeviceServiceClient deviceClient)
        {
            m_deviceServiceClient = deviceClient;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var claims = User.Claims.ToDictionary(C => C.Type, C => C.Value);
            return Ok(claims);
        }
        // Device Service
         

        // Setting Service

        // Scan Service

        //

    }
}