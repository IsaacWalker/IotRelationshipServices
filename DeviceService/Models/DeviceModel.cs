/***************************************************
    DeviceModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.DeviceService.Models
{
    /// <summary>
    /// Model for a device
    /// </summary>
    public class DeviceModel
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }


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
