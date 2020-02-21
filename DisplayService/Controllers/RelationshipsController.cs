using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web.Iot.DisplayService.Models;
using Web.Iot.Shared.MongoDB;

namespace Web.Iot.DisplayService.Controllers
{
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly IMongoCollection<Scan> m_scanCollection;


        private static readonly float DistanceThreshold = 5.0f;


        private static DateTime now = DateTime.Now; 


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
            long hourAgo = now.AddHours(-1).Ticks;

            /*

                        var filter = builder.Where(S => Math.Abs(S.Kinematics.Latitude - scan.Kinematics.Latitude) < DistanceThreshold &&
                         Math.Abs(S.Kinematics.Longitude - scan.Kinematics.Longitude) < DistanceThreshold && S.DeviceId != DeviceId);

                        if (m_scanCollection.Find(filter).ToList() != null)
                        {
                            var nearby_scans = m_scanCollection.Find(filter).ToList();
                            var time_filter = builder.Where(S => S.Timestamp > hourAgo);
                            var recent_scans = m_scanCollection.Find(time_filter).ToList();
                        }
                        */


            /*
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
                        */

            
            var device1 = new DisplayDeviceModel()
            {
                Latitude = 53.343,
                Longitude = -6.250,
                Rotation = 0,
                Name = "Isaac"
            };
            var device2 = new DisplayDeviceModel()
            {
                Latitude = 53.346,
                Longitude = -6.254,
                Rotation = 0,
                Name = "Anna"
            };
            List<DisplayDeviceModel> deviceModels = new List<DisplayDeviceModel>() { device1, device2 };
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