/***************************************************
    BluetoothDeviceModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.ScanService.Models
{
    /// <summary>
    /// A device found in a Bluetooth scan
    /// </summary>
    public sealed class BluetoothDeviceModel
    {
        /// <summary>
        /// The received signal strength
        /// </summary>
        public int Rssi { get; set; }


        /// <summary>
        /// Transmit power in dBm
        /// </summary>
        public int TxPower { get; set; }


        /// <summary>
        /// Gets the Bluetooth Device type
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// Gets the bluetooth friendly name of the device
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Hardware address of the bluetooth device
        /// </summary>
        public string HardwareAddress { get; set; }
    }
}
