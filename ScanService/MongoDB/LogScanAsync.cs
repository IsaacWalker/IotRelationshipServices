﻿/***************************************************
    LogScanAsync.cs

    Isaac Walker
****************************************************/

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Web.Iot.Shared.Message;
using Web.Iot.ScanService.MongoDB.Data;

namespace Web.Iot.ScanService.MongoDB
{
    /// <summary>
    /// Log Scan Processor
    /// </summary>
    public sealed class LogScanAsync : IScanProcessor
    {
        private readonly ILogger<LogScanAsync> m_logger;


        private readonly IMongoCollection<Scan> m_scanCollection;

      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name=""></param>
        public LogScanAsync(IMongoCollection<Scan> scanCollection, ILogger<LogScanAsync> logger)
        {
            m_scanCollection = scanCollection;
            m_logger = logger;
        }


        /// <summary>
        /// Runs the processor
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public async Task<LogScanResponse> Run(LogScanRequest Request)
        {
            m_logger.LogInformation(LogEventId.LogScanStart, string.Format("Sending {0} Scans to MongoDB.", Request.Scans.Count));

            LogScanResponse Response = null;

            try
            {
                await m_scanCollection.InsertManyAsync(Request.Scans);
                Response = new LogScanResponse(true);
                m_logger.LogInformation(LogEventId.LogScanSuccess, "Scans inserted into MongoDB.");
            }
            catch(Exception e)
            {
                m_logger.LogError(LogEventId.LogScanError, "Error Logging scans: {0}", e.ToString());
            }

            return Response;         
        }

        public async Task<GetScanCountResponse> Run(GetScanCountRequest Request)
        {

            GetScanCountResponse Response = null;

           try
            {
                long Count = await m_scanCollection.CountDocumentsAsync(FilterDefinition<Scan>.Empty);
                Response = new GetScanCountResponse(true, Count);
            }
            catch(Exception e)
            {
                Response = new GetScanCountResponse(false, -1);
            }

            return Response;        
        }
    }
}
