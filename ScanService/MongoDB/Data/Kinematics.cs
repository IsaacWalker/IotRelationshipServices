/***************************************************
    Kinematics.cs

    Isaac Walker
****************************************************/

using Microsoft.Spatial;
using MongoDB.Bson.Serialization.Attributes;
using System.Numerics;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized device kinematics
    /// </summary>
    public sealed class Kinematics
    {
        /// <summary>
        /// Device acceleration
        /// </summary>
        [BsonElement("acceleration")]
        public Vector3 Acceleration { get; set; }


        /// <summary>
        /// Device Location
        /// </summary>
        [BsonElement("location")]
        public GeographyPoint Location { get; set; }
    }
}
