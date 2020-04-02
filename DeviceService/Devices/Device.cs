/***************************************************
    Device.cs

    Isaac Walker
****************************************************/

using System;

namespace Web.Iot.DeviceService.Devices
{
    public class Device
    {
        /// <summary>
        /// The Media Access Control for devices NIC (WiFi)
        /// </summary>
        public string MacAddress { get; set; }


        /// <summary>
        /// Bluetooth of name
        /// </summary>
        public string BluetoothName { get; set; }


        /// <summary>
        /// The manfacturer of the device
        /// </summary>
        public string Manufacturer { get; set; }


        /// <summary>
        /// The model of the device
        /// </summary>
        public string Model { get; set; }


        /// <summary>
        /// Date of creation of this device
        /// </summary>
        public DateTime DateOfCreation { get; set; }
    }
}
