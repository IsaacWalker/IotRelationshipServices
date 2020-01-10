/***************************************************
    Scan.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Scan serialization Model
    /// </summary>
    public sealed class Scan
    {
        /// <summary>
        /// Scan Id
        /// </summary>
        [BsonId]
        [JsonIgnore]
        public ObjectId _id { get; set; }


        /// <summary>
        /// Device Id
        /// </summary>
        [BsonElement("device_id")]
        [JsonIgnore]
        public long DeviceId { get; set; }


        /// <summary>
        /// DateTime of Scan
        /// </summary>
        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }


        /// <summary>
        /// The kinematics of the device
        /// </summary>
        [BsonElement("kinematics")]
        [JsonProperty("kinematics")]
        public Kinematics Kinematics { get; set; }


        /// <summary>
        /// Wifi Devices discovered in the Scan
        /// </summary>
        [BsonElement("wifi_devices")]
        [JsonProperty("wifi_devices")]
        public List<WifiDevice> WifiDevices{get; set;}


        /// <summary>
        /// Bluetooth devices discovered in the Scan
        /// </summary>
        [BsonElement("bluetooth_devices")]
        [JsonProperty("bluetooth_devices")]
        public List<BluetoothDevice> BluetoothDevices { get; set; }
    }
}
