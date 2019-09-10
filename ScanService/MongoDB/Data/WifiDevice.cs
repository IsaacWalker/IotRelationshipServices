/***************************************************
    WifiDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized Discovered WifiDevice
    /// </summary>
    public sealed class WifiDevice
    {
        /// <summary>
        /// Basic Service Set Identifier
        /// </summary>
        [BsonElement("bssid")]
        public string BSSID { get; set; }


        /// <summary>
        /// Service Set Identifierf
        /// </summary>
        [BsonElement("ssid")]
        public string SSID { get; set; }


        /// <summary>
        /// Frequency of device
        /// </summary>
        [BsonElement("frequency")]
        public float Frequency { get; set; }


        /// <summary>
        /// The width of the channel
        /// </summary>
        [BsonElement("channel_width")]
        public uint ChannelWidth { get; set; }


        /// <summary>
        /// Level in dBm
        /// </summary>
        [BsonElement("level")]
        public uint Level { get; set; }


        /// <summary>
        /// The name of the Venue 
        /// </summary>
        [BsonElement("venue_name")]
        public string VenueName { get; set; }
    }
}
