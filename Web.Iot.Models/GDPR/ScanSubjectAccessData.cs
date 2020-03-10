using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Models.GDPR
{
    /// <summary>
    /// Subject access request for the scan data
    /// </summary>
    public class ScanSubjectAccessData
    {
        /// <summary>
        /// Wifi Scan Count
        /// </summary>
        public int WifiScansCount { get; set; }


        /// <summary>
        /// Bluetooth Scan Count
        /// </summary>
        public int BluetoothScanCount { get; set; }


        /// <summary>
        /// Scan Count
        /// </summary>
        public int ScanCount { get; set; }
    }
}
