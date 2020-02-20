using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web.Iot.Shared.MongoDB;

namespace DisplayService.Controllers
{
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly IMongoCollection<Scan> m_scanCollection;


        private static readonly float DistanceThreshold = 5.0f;


        public RelationshipsController(IMongoCollection<Scan> scanCollection)
        {
            m_scanCollection = scanCollection;
        }


        [HttpGet]
        [Route("api/[controller]/getStaticDisplay")]
        public IActionResult GetStaticDisplay([FromQuery] int DeviceId)
        {
            var builder = new FilterDefinitionBuilder<Scan>();
            var devicefilter = builder.Where(S => S.DeviceId == DeviceId);
            Scan scan = m_scanCollection.Find(devicefilter).FirstOrDefault();


            //TODO temporal filtering
            var filter = builder.Where(S => Math.Abs(S.Kinematics.Latitude - scan.Kinematics.Latitude) < DistanceThreshold &&
             Math.Abs(S.Kinematics.Longitude - scan.Kinematics.Longitude) < DistanceThreshold && S.DeviceId != DeviceId);
            var nearby_scans = m_scanCollection.Find(filter).ToList();

            List<DisplayDeviceModel> deviceModels = new List<DisplayDeviceModel>();

            foreach(var nearbyScan in nearby_scans)
            {
                deviceModels.Add(
                    new DisplayDeviceModel()
                    {
                        Name = nearbyScan.DeviceId.ToString(),
                        Latitude = nearbyScan.Kinematics.Latitude,
                        Longitude = nearbyScan.Kinematics.Longitude,
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
    }
}