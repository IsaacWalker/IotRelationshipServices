/***************************************************
    WifiDeviceModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.ScanService.Models
{
    /// <summary>
    /// A device found in a  Wi-Fi scan
    /// </summary>
    public sealed class WifiDeviceModel
    {
        /// <summary>
        /// Basic Service Set Identifier
        /// </summary>
        public string BSSID { get; set; }


        /// <summary>
        /// Service Set Identifierf
        /// </summary>
        public string SSID { get; set; }


        /// <summary>
        /// Frequency of device
        /// </summary>
        public int Frequency { get; set; }


        /// <summary>
        /// The width of the channel
        /// </summary>
        public uint ChannelWidth { get; set; }


        /// <summary>
        /// Level in dBm (Rssi)
        /// </summary>
        public uint Level { get; set; }


        /// <summary>
        /// The name of the Venue 
        /// </summary>
        public string VenueName { get; set; }


        /// <summary>
        /// Indicates Passpoint operator name
        /// </summary>
        public string OperatorFriendlyName { get; set; }


        /// <summary>
        /// Describes the capabilites of the device
        /// </summary>
        public string Capabilities { get; set; }
    }
}
