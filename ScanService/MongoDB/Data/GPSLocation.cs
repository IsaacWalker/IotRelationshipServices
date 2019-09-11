using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialization of GPSLocation
    /// </summary>
    public class GPSLocation
    {
        /// <summary>
        /// Longitude 
        /// </summary>
        [BsonElement("longitude")]
        public float Longitude { get; set; }


        /// <summary>
        /// latitude
        /// </summary>
        [BsonElement("latitude")]
        public float Latitude { get; set; }
    }
}
