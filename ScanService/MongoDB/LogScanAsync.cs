/***************************************************
    LogScanAsync.cs

    Isaac Walker
****************************************************/

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Web.Iot.Shared.Message;
using Web.Iot.Client.SettingService;
using Web.Iot.Models.MongoDB;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Web.Iot.ScanService.MongoDB
{
    /// <summary>
    /// Log Scan Processor
    /// </summary>
    public sealed class LogScanAsync : IScanProcessor
    {
        private readonly ILogger<LogScanAsync> m_logger;


        private readonly IMongoCollection<ScanModel> m_scanCollection;


        private readonly ISettingServiceClient m_settingServiceClient;
      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name=""></param>
        public LogScanAsync(IMongoCollection<ScanModel> scanCollection, ILogger<LogScanAsync> logger, ISettingServiceClient settingServiceClient)
        {
            m_scanCollection = scanCollection;
            m_settingServiceClient = settingServiceClient;
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

            foreach(ScanModel scan in Request.Scans)
            {
                /// Was a local configuraiton used in this scan?
                if (scan.Configuration != null && scan.Configuration.Count != 0)
                {
                    var coords = new GeoJson2DCoordinates(scan.Kinematics.Latitude, scan.Kinematics.Longitude);
                    scan.Kinematics.Location = GeoJson.Point<GeoJson2DCoordinates>(coords);
                    // if so, then register that configuration and set the global Id to it
                    scan.GlobalConfigurationId = await m_settingServiceClient.RegisterConfigurationAsync(scan.Configuration);
                }
            }

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
                long Count = await m_scanCollection.CountDocumentsAsync(FilterDefinition<ScanModel>.Empty);
                Response = new GetScanCountResponse(true, Count);
            }
            catch (Exception)
            {
                Response = new GetScanCountResponse(false, -1);
            }

            return Response;        
        }
    }
}
