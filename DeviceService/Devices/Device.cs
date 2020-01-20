/***************************************************
    Device.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.DeviceService.Devices
{
    public class Device
    {
        /// <summary>
        /// Id of the Phone, used for pseudonimization
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// The Media Access Control for devices NIC (WiFi)
        /// </summary>
        public string MacAddress { get; set; }


        /// <summary>
        /// Hardware address of the local bluetooth adapter
        /// </summary>
        public string BluetoothHardwareAddress { get; set; }


        /// <summary>
        /// The manfacturer of the device
        /// </summary>
        public string Manufacturer { get; set; }


        /// <summary>
        /// THe model of the device
        /// </summary>
        public string Model { get; set; }
    }
}
