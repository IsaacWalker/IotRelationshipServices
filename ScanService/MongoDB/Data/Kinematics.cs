/***************************************************
    Kinematics.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;

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
        public LinearAcceleration Acceleration { get; set; }


        /// <summary>
        /// Device Location
        /// </summary>
        [BsonElement("location")]
        public GPSLocation Location { get; set; }
    }
}
