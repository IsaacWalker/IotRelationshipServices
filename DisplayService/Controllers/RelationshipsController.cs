using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Web.Iot.DisplayService.Models;
using Web.Iot.Models.MongoDB;

namespace Web.Iot.DisplayService.Controllers
{
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly IMongoCollection<ScanModel> m_scanCollection;


        private static readonly double DistanceThreshold = 5.0;


        private static DateTime now = DateTime.Now;


        public RelationshipsController(IMongoCollection<ScanModel> scanCollection)
        {
            m_scanCollection = scanCollection;
        }


        [HttpGet]
        [Route("api/[controller]/getStaticDisplay")]
        public IActionResult GetStaticDisplay([FromQuery] int deviceId)
        {
            var recentScans = GetRecentScans(deviceId);
            var mostRecentScan = recentScans.FirstOrDefault();
            var nearbyScans = GetNearbyScans(mostRecentScan);
            var model = CreateStaticDisplayModel(nearbyScans, mostRecentScan);
            
            return Ok(model);
        }

        [HttpGet]
        [Route("api/[controller]/getHistoricalDisplay")]
        public IActionResult GetHistoricalDisplay([FromQuery] int deviceId)
        {
            var recentScans = GetRecentScans(deviceId);
            List<StaticDisplayModel> staticModels = new List<StaticDisplayModel>();
            foreach(var scan in recentScans)
            {
                var nearbyScans = GetNearbyScans(scan);
                var model = CreateStaticDisplayModel(nearbyScans, scan);
                staticModels.Add(model);
            }
            var historicModel = new HistoricalDisplayModel() 
            { 
                DisplayModels = staticModels 
            };


            return Ok(historicModel);
        }


        private List<ScanModel> GetRecentScans(int deviceId)
        {
            var builder = new FilterDefinitionBuilder<ScanModel>();
            var devicefilter = builder.Where(S => S.DeviceId == deviceId);
            var scans = m_scanCollection
                .Find(devicefilter)
                .SortBy(S => S.Timestamp)
                .ToList();

            return scans;
        }

        private List<ScanModel> GetNearbyScans(ScanModel scan)
        {
            var builder = new FilterDefinitionBuilder<ScanModel>();
            var filter = builder.Near(S => S.Kinematics.Location, scan.Kinematics.Location, minDistance: 0.0, maxDistance: DistanceThreshold);

            var nearby_scans = m_scanCollection.Find(filter).ToList();
            return nearby_scans;
        }


        private StaticDisplayModel CreateStaticDisplayModel(List<ScanModel> nearby_scans, ScanModel scan)
        {
            List<DisplayDeviceModel> deviceModels = new List<DisplayDeviceModel>();

            foreach (var nearbyScan in nearby_scans)
            {
                deviceModels.Add(
                    new DisplayDeviceModel()
                    {
                        Name = nearbyScan.DeviceId.ToString(),
                        Latitude = nearbyScan.Kinematics.Location.Coordinates.X,
                        Longitude = nearbyScan.Kinematics.Location.Coordinates.Y,
                        Rotation = nearbyScan.Kinematics.Azimuth
                    }
                    );
            }

            StaticDisplayModel model = new StaticDisplayModel()
            {
                Devices = deviceModels,
                Timestamp = scan.Timestamp,
            };
            return model;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok("Working");
        }


    }
}