using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Models.GDPR
{
    public class SubjectAccessRequestModel
    {
        /// <summary>
        /// Id of the device
        /// </summary>
        public int DeviceId { get; set; }


        /// <summary>
        /// Hardware address of the wifi
        /// </summary>
        public string WifiMAC { get; set; }


        /// <summary>
        /// Bluetooth hardware address
        /// </summary>
        public string BluetoothMAC { get; set; }


        /// <summary>
        /// DateTime the request was issued
        /// </summary>
        public DateTime DateTimeOfRequest { get;  set; }
    }
}
