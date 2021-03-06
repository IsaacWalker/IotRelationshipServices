﻿/***************************************************
    WifiDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Web.Iot.Models.MongoDB
{
    /// <summary>
    /// Serialized Discovered WifiDevice
    /// </summary>
    public sealed class WifiDeviceModel
    {
        /// <summary>
        /// Datetime of when the device was detected
        /// </summary>
        [BsonElement("dateTime")]
        public DateTime DateTime { get; set; }


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
        /// Describes the capabilites of the device
        /// </summary>
        [BsonElement("capabilities")]
        public string Capabilities { get; set; }


        /// <summary>
        /// Level in dBm
        /// </summary>
        [BsonElement("level")]
        public int Level { get; set; }


        /// <summary>
        /// Indicates Passpoint operator name
        /// </summary>
        [BsonElement("operatorFriendlyName")]
        public string OperatorFriendlyName { get; set; }


        /// <summary>
        /// The name of the Venue 
        /// </summary>
        [BsonElement("venueName")]
        public string VenueName { get; set; }
    }
}
