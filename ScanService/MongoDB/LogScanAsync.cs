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
using Web.Iot.Models.GDPR;
using System.Collections.Generic;

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
                var coords = new GeoJson2DCoordinates(scan.Kinematics.Latitude, scan.Kinematics.Longitude);
                scan.Kinematics.Location = GeoJson.Point<GeoJson2DCoordinates>(coords);

                /// Was a local configuraiton used in this scan?
                if (scan.Configuration != null && scan.Configuration.Count != 0)
                {
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

        public Task<GetScanSubjectAccessResponse> Run(GetScanSubjectAccessRequest Request)
        {
            try
            {
                var scans = m_scanCollection.AsQueryable()
                .Where(S => S.DeviceId == Request.DeviceId)
                .ToList();

                int wifiDeviceCount = scans.Sum(S => S.WifiDevices.Count());
                int bluetoothDeviceCount = scans.Sum(S => S.BluetoothDevices.Count());
                int scanCount = scans.Count();

                var dataModel = new PersonalDataModel<ScanSubjectAccessData>()
                {
                    Data = new ScanSubjectAccessData()
                    {
                        BluetoothScanCount = bluetoothDeviceCount,
                        ScanCount = scanCount,
                        WifiScansCount = wifiDeviceCount
                    },
                    Categories = s_scanSubjectCategories,
                    PersonalDataName = "Scan Data",
                    DateOfCollection = DateTime.Now.Date - TimeSpan.FromDays(12),
                    DateOfDeletion = DateTime.Now.Date + TimeSpan.FromDays(12)

                };

                var response = new GetScanSubjectAccessResponse(dataModel, true);

                return Task.FromResult(response);
            }
            catch (Exception _)
            {
                return Task.FromResult(new GetScanSubjectAccessResponse(default, false));
            }
        }

        private static readonly IList<string> s_scanSubjectCategories = new List<string>()
        {
            "Personally Identifiable Information"
        };
    }
}
