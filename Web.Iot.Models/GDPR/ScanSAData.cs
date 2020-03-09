using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Models.GDPR
{
    /// <summary>
    /// Subject access request for the scan data
    /// </summary>
    public class ScanSAData
    {
        public double Longitude { get; set; }


        public double Latitude { get; set; }


        public DateTime DateTime { get; set; }
    }
}
