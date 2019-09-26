/***************************************************
    LinearAcceleration.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// MongoDB Serialization of LinearAcceleration
    /// </summary>
    public sealed class LinearAcceleration
    {
        /// <summary>
        /// Linear acceleration in X
        /// </summary>
        [BsonElement("x")]
        public float X { get; set; }


        /// <summary>
        /// Acceleration in Y
        /// </summary>
        [BsonElement("y")]
        public float Y { get; set; }


        /// <summary>
        /// Acceleration in Z
        /// </summary>
        [BsonElement("z")]
        public float Z { get; set; }
    }
}
