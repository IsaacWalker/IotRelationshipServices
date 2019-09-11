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
        /// Media Access Control
        /// </summary>
        public string MAC { get; set; }


        /// <summary>
        /// Public Identifier
        /// </summary>
        public string Name { get; set; }
    }
}
