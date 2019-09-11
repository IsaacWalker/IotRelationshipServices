/***************************************************
    Scan.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        public ObjectId _id { get; set; }


        /// <summary>
        /// Device Id
        /// </summary>
        [BsonElement("device_id")]
        public long DeviceId { get; set; }


        /// <summary>
        /// DateTime of Scan
        /// </summary>
        [BsonElement("date_time")]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// Is Wifi Enabled
        /// </summary>
        [BsonElement("is_wifi_enabled")]
        public bool IsWifiEnabled { get; set; }


        /// <summary>
        /// Is Bluetooth Enabled
        /// </summary>
        [BsonElement("is_bluetooth_enabled")]
        public bool IsBluetoothEnabled { get; set; }


        /// <summary>
        /// Is Kinematics Enabled
        /// </summary>
        [BsonElement("is_kinematics_enabled")]
        public bool IsKinematicsEnabled { get; set; }


        /// <summary>
        /// Wifi Devices discovered in the Scan
        /// </summary>
        [BsonElement("wifi_devices")]
        public List<WifiDevice> WifiDevices{get; set;}


        /// <summary>
        /// Bluetooth devices discovered in the Scan
        /// </summary>
        [BsonElement("bluetooth_devices")]
        public List<BluetoothDevice> BluetoothDevices { get; set; }


        /// <summary>
        /// The kinematics of the device
        /// </summary>
        [BsonElement("kinematics")]
        public Kinematics Kinematics { get; set; }
    }
}
