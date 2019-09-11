/***************************************************
    GPSLocationModel.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.ScanService.Models
{
    /// <summary>
    /// GPS reading from Phone
    /// </summary>
    public class GPSLocationModel
    {
        /// <summary>
        /// Longitude 
        /// </summary>
        public float Longitude { get; set; }


        /// <summary>
        /// latitude
        /// </summary>
        public float Latitude { get; set; }
    }
}
