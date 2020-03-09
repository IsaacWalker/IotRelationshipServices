/***************************************************
    CreateDeviceRequest.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;
using Web.Iot.DeviceService.Devices;
using System;

namespace Web.Iot.DeviceService.Contracts
{
    public class CreateDeviceRequest : Request
    {
        /// <summary>
        /// Mac Address
        /// </summary>
        public string MacAddress { get; private set; }


        /// <summary>
        /// Bluetooth Name
        /// </summary>
        public string BluetoothName { get; private set; }


        /// <summary>
        /// Manufacturer 
        /// </summary>
        public string Manufacturer { get; private set; }


        /// <summary>
        /// Device Model
        /// </summary>
        public string DeviceModel { get; private set; }


        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime DateOfCreation { get; private set; }


        public CreateDeviceRequest(
            string MacAddress,
            string BluetoothName,
            string Manufacturer,
            string DeviceModel,
            DateTime dateOfCreation)
        {
            this.MacAddress = MacAddress;
            this.BluetoothName = BluetoothName;
            this.Manufacturer = Manufacturer;
            this.DeviceModel = DeviceModel;
            DateOfCreation = dateOfCreation;
        }
    }
}
