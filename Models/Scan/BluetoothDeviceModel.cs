/***************************************************
    BluetoothDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Web.Iot.Models.MongoDB
{
    /// <summary>
    /// Serialized discovered bluetooth device
    /// </summary>
    public sealed class BluetoothDeviceModel
    {
        /// <summary>
        /// The datetime of when the device was detected
        /// </summary>
        [BsonElement("dateTime")]
        public DateTime DateTime { get; set; }


        /// <summary>
        /// Gets the bluetooth friendly name of the device
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }


        /// <summary>
        /// Gets the Bluetooth Device type
        /// </summary>
        [BsonElement("type")]
        public string Type { get; set; }


        /// <summary>
        /// Hardware address of the bluetooth device
        /// </summary>
        [BsonElement("address")]
        public string Address { get; set; }


        /// <summary>
        /// Received signal Strength Indicator
        /// </summary>
        [BsonElement("rssi")]
        public int RSSI { get; set; }


        /// <summary>
        /// TX Power
        /// </summary>
        [BsonElement("powerLevel")]
        public int PowerLevel { get; set; }
    }
}
