﻿/***************************************************
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
using Web.Iot.ScanService.MongoDB.Data;
using System.Collections.Generic;

namespace Web.Iot.ScanService.Controllers
{
    [Route("api/[controller]")]
    public class ScanController : Controller
    {
        private readonly ILogger m_logger;


        private readonly IProcessor<LogScanRequest, LogScanResponse> m_processor;

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="logger"></param>
        public ScanController(IProcessor<LogScanRequest, LogScanResponse> processor, ILogger<ScanController> logger)
        {
            m_processor = processor;
            m_logger = logger;
        }


        /// <summary>
        /// Batch Scan endpoint
        /// </summary>
        /// <param name="Scan"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScanBatchModel ScanBatch)
        {
            if(ScanBatch == null || ScanBatch.Scans == null || ScanBatch.Scans.Count == 0)
            {
                return BadRequest();
            }

            m_logger.LogDebug(LogEventId.ScanBatchPostStart, string.Format("Scans Received: From {0}, Number {1}",
                ScanBatch.DeviceId, ScanBatch.Scans.Count));

            LogScanRequest Request = new LogScanRequest(ScanBatch.DeviceId, ScanBatch.Scans);
            LogScanResponse Response = await m_processor.Run(Request);

            m_logger.LogDebug(LogEventId.ScanBatchPostEnd, "Scan Batch processed: {0}.", Response.Success ? "Success" : "fail");

            if (!Response.Success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
