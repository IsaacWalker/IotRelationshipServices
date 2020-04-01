using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Iot.APIGatewayService.Security;

namespace Web.Iot.APIGatewayService.Controllers
{
    [ApiController]
    public class ForwardController : ControllerBase
    {
        private readonly IHttpContextAccessor m_httpContext;


        private readonly IRequestSignValidator m_signValidator;


        public ForwardController(IHttpContextAccessor accessor, IRequestSignValidator signValidator)
        {
            m_httpContext = accessor;
            m_signValidator = signValidator;
        }

        // Device Service
         

        // Setting Service

        // Scan Service

        //

        private bool IsValidSignature()
        {
            string requestSignature = m_httpContext.HttpContext.Request.Headers["IR-SIGN"];

            SignValidatorMessage message = new SignValidatorMessage(
                m_httpContext.HttpContext.Request.Path.Value,
                m_httpContext.HttpContext.Request.Headers["Authorization"]);

            return true;
        }
    }
}