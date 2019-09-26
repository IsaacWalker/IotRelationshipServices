/***************************************************
    GPSLocation.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;

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
