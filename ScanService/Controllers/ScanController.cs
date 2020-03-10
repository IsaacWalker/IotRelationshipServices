/***************************************************
    ScanController.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Iot.Shared.Message;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.ScanService.Models;
using Web.Iot.ScanService.MongoDB;
using System.Collections.Generic;

namespace Web.Iot.ScanService.Controllers
{
    public class ScanController : Controller
    {
        private readonly ILogger m_logger;


        private readonly IScanProcessor m_processor;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="logger"></param>
        public ScanController(IScanProcessor processor, ILogger<ScanController> logger)
        {
            m_processor = processor;
            m_logger = logger;
        }


        /// <summary>
        /// Batch Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] ScanBatchModel ScanBatch)
        {

            if(ScanBatch == null || ScanBatch.Scans == null || ScanBatch.Scans.Count == 0)
            {
                return BadRequest(string.Format("Request is null {0}", ScanBatch == null));
            }

            m_logger.LogDebug(LogEventId.ScanBatchPostStart, string.Format("Scans Received: From {0}, Number {1}",
                ScanBatch.DeviceId, ScanBatch.Scans.Count));

            LogScanRequest Request = new LogScanRequest(ScanBatch.DeviceId, ScanBatch.Scans);
            LogScanResponse Response = await m_processor.Run(Request);

            m_logger.LogDebug(LogEventId.ScanBatchPostEnd, "Scan Batch processed: {0}.", Response.Success ? "Success" : "fail");

            if (!Response.Success)
            {
                return BadRequest("Failed to insert into Database");
            }

            return Ok();
        }


        [Route("api/[controller]/count")]
        public async Task<IActionResult> Count()
        {
            var response = await m_processor.Run(new GetScanCountRequest());
            
            if(!response.Success)
            {
                return BadRequest();
            }

            return Ok(response.Count);
        }

        [Route("api/[controller]/sar")]
        public async Task<IActionResult> GetPersonalData([FromQuery] int deviceId)
        {
            var response = await m_processor.Run(new GetScanSubjectAccessRequest(deviceId));

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
