/***************************************************
    BluetoothDevice.cs

    Isaac Walker
****************************************************/

using MongoDB.Bson.Serialization.Attributes;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// Serialized discovered bluetooth device
    /// </summary>
    public sealed class BluetoothDevice
    {
        /// <summary>
        /// Media Access Control
        /// </summary>
        [BsonElement("mac")]
        public string MAC { get; set; }


        /// <summary>
        /// Public Identifier
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
