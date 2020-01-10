/***************************************************
    BluetoothDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized discovered bluetooth device
    /// </summary>
    public sealed class BluetoothDevice
    {
        /// <summary>
        /// The timestamp of when the device was detected
        /// </summary>
        [BsonElement("timestamp")]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }


        /// <summary>
        /// Gets the bluetooth friendly name of the device
        /// </summary>
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// Gets the Bluetooth Device type
        /// </summary>
        [BsonElement("type")]
        [JsonProperty("type")]
        public string Type { get; set; }


        /// <summary>
        /// Hardware address of the bluetooth device
        /// </summary>
        [BsonElement("address")]
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
