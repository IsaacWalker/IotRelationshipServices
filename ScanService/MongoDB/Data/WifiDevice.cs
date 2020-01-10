/***************************************************
    WifiDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized Discovered WifiDevice
    /// </summary>
    public sealed class WifiDevice
    {
        /// <summary>
        /// Timestamp of when the device was detected
        /// </summary>
        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }


        /// <summary>
        /// Basic Service Set Identifier
        /// </summary>
        [BsonElement("bssid")]
        [JsonProperty("bssid")]
        public string BSSID { get; set; }


        /// <summary>
        /// Service Set Identifierf
        /// </summary>
        [BsonElement("ssid")]
        [JsonProperty("ssid")]
        public string SSID { get; set; }


        /// <summary>
        /// Describes the capabilites of the device
        /// </summary>
        [BsonElement("capabilities")]
        [JsonProperty("capabilities")]
        public string Capabilities { get; set; }


        /// <summary>
        /// Level in dBm
        /// </summary>
        [BsonElement("level")]
        [JsonProperty("level")]
        public uint Level { get; set; }


        /// <summary>
        /// Indicates Passpoint operator name
        /// </summary>
        [BsonElement("operator_friendly_name")]
        [JsonProperty("operator_friendly_name")]
        public string OperatorFriendlyName { get; set; }


        /// <summary>
        /// The name of the Venue 
        /// </summary>
        [BsonElement("venue_name")]
        [JsonProperty("venue_name")]
        public string VenueName { get; set; }
    }
}
