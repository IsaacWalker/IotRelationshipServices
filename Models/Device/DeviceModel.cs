/***************************************************
    DeviceModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.Models.Device
{
    /// <summary>
    /// Model for a device
    /// </summary>
    public class DeviceModel
    {
        /// <summary>
        /// Mac Address (for Wifi)
        /// </summary>
        public string MacAddress { get; set; }


        /// <summary>
        /// Name as appearing on bluetooth
        /// </summary>
        public string BluetoothName { get; set; }


        /// <summary>
        /// Manufacturer of the device
        /// </summary>
        public string Manufacturer { get; set; }


        /// <summary>
        /// Model of the device
        /// </summary>
        public string Model { get; set; }
    }
}
