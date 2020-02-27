/***************************************************
    Scan.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Web.Iot.Models.Setting;

namespace Web.Iot.Models.MongoDB
{
    /// <summary>
    /// Scan serialization Model
    /// </summary>
    public sealed class ScanModel
    {
        /// <summary>
        /// Scan Id
        /// </summary>
        [BsonId]
        [JsonIgnore]
        public ObjectId _id { get; set; }


        /// <summary>
        /// The configuration Id
        /// </summary>
        [BsonElement("globalConfigurationId")]
        public int GlobalConfigurationId { get; set; }


        /// <summary>
        /// The local configuration, if it was sent
        /// </summary>
        [BsonIgnore]
        public List<SettingModel> Configuration { get; set; }


        /// <summary>
        /// Device Id
        /// </summary>
        [BsonElement("deviceId")]
        [JsonIgnore]
        public long DeviceId { get; set; }


        /// <summary>
        /// DateTime of Scan
        /// </summary>
        [BsonElement("datetime")]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// The kinematics of the device
        /// </summary>
        [BsonElement("kinematics")]
        public KinematicsModel Kinematics { get; set; }


        /// <summary>
        /// Wifi Devices discovered in the Scan
        /// </summary>
        [BsonElement("wifiDevices")]
        public List<WifiDeviceModel> WifiDevices{get; set;}


        /// <summary>
        /// Bluetooth devices discovered in the Scan
        /// </summary>
        [BsonElement("bluetoothDevices")]
        public List<BluetoothDeviceModel> BluetoothDevices { get; set; }
    }
}
