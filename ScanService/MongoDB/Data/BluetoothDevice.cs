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
        /// The received signal strength
        /// </summary>
        [BsonElement("rssi")]
        public int Rssi { get; set; }


        /// <summary>
        /// Transmit power in dBm
        /// </summary>
        [BsonElement("tx_power")]
        public int TxPower { get; set; }


        /// <summary>
        /// Gets the Bluetooth Device type
        /// </summary>
        [BsonElement("type")]
        public string Type { get; set; }


        /// <summary>
        /// Gets the bluetooth friendly name of the device
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }


        /// <summary>
        /// Hardware address of the bluetooth device
        /// </summary>
        [BsonElement("hardware_address")]
        public string HardwareAddress { get; set; }
    }
}
