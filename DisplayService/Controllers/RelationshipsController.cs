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
            var builder = new FilterDefinitionBuilder<ScanModel>();
            var devicefilter = builder.Where(S => S.DeviceId == deviceId);
            ScanModel scan = m_scanCollection.Find(devicefilter).FirstOrDefault();


            // var filter = builder.Where(S => Math.Abs(S.Kinematics.Latitude - scan.Kinematics.Latitude) < DistanceThreshold &&
            //Math.Abs(S.Kinematics.Longitude - scan.Kinematics.Longitude) < DistanceThreshold && S.DeviceId != deviceId);

           
            var filter = builder.Near(S => S.Kinematics.Location, scan.Kinematics.Location, minDistance: 0.0, maxDistance: DistanceThreshold);

            var nearby_scans = m_scanCollection.Find(filter).ToList();
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
                Devices = deviceModels
            };

            return Ok(model);
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok("Working");
        }


    }
}