/***************************************************
    ScanModel.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;

namespace Web.Iot.ScanService.Models
{
    /// <summary>
    /// A Device Scan
    /// </summary>
    public sealed class ScanModel
    {
        /// <summary>
        /// Date and time of scan
        /// </summary>
        public DateTime DateTime { get; set;}


        /// <summary>
        /// Was Wi-Fi enabled in the scan
        /// </summary>
        public bool IsWifiEnabled { get; set; }


        /// <summary>
        /// Is Bluetooth enabled in the scan
        /// </summary>
        public bool IsBluetoothEnabled { get; set; }


        /// <summary>
        /// Was Kinematics enabled in the scan 
        /// </summary>
        public bool IsKinematicsEnabled { get; set; }


        /// <summary>
        /// The Devices found from the Bluetooth scan
        /// </summary>
        public List<BluetoothDeviceModel> BluetoothDevices { get; set; }


        /// <summary>
        /// The devices scan in the Wifi Scan
        /// </summary>
        public List<WifiDeviceModel> WifiDevices { get; set; }


        /// <summary>
        /// Kinematics of the Device at scan
        /// </summary>
        public KinematicsModel Kinematics { get; set; }
    }
}
