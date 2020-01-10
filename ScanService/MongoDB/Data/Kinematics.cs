/***************************************************
    Kinematics.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized device kinematics
    /// </summary>
    public sealed class Kinematics
    {
        /// <summary>
        /// Timestamp of when the kinematics of the device we're read
        /// </summary>
        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }


        /// <summary>
        /// The altitude of the device
        /// </summary>
        [BsonElement("altitude")]
        [JsonProperty("altitude")]
        public double Altitude { get; set; }


        /// <summary>
        /// The latitude of the device
        /// </summary>
        [BsonElement("latitude")]
        [JsonProperty("latitude")]
        public double Latitude { get; set; }


        /// <summary>
        /// The longitude of the device
        /// </summary>
        [BsonElement("longitude")]
        [JsonProperty("longitude")]
        public double Longitude { get; set; }


        /// <summary>
        /// The azimuth of the device
        /// </summary>
        [BsonElement("azimuth")]
        [JsonProperty("azimuth")]
        public double Azimuth { get; set; }


        /// <summary>
        /// The pitch of the device
        /// </summary>
        [BsonElement("pitch")]
        [JsonProperty("pitch")]
        public double Pitch { get; set; }


        /// <summary>
        /// The roll of the device
        /// </summary>
        [BsonElement("roll")]
        [JsonProperty("roll")]
        public double Roll { get; set; }


        /// <summary>
        /// The acceleration of the device on the X axis
        /// </summary>
        [BsonElement("acceleration_x")]
        [JsonProperty("acceleration_x")]
        public double AccelerationX { get; set; }


        /// <summary>
        /// THe acceleration of the device on the Y axis
        /// </summary>
        [BsonElement("acceleration_y")]
        [JsonProperty("acceleration_y")]
        public double AccelerationY { get; set; }


        /// <summary>
        /// The acceleration of the device on the z axis
        /// </summary>
        [BsonElement("acceleration_z")]
        [JsonProperty("acceleration_z")]
        public double AccelerationZ { get; set; }
    }
}
