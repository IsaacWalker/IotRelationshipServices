/***************************************************
    Kinematics.cs

    Isaac Walker
****************************************************/

using Microsoft.Spatial;
using System.Numerics;

namespace Web.Iot.ScanService.Models
{
    /// <summary>
    /// Kinematics 
    /// </summary>
    public sealed class KinematicsModel
    {
        /// <summary>
        /// The reading from the accelerometer
        /// </summary>
        public Vector3 Acceleration { get; set; }


        /// <summary>
        /// The location of the Scan
        /// </summary>
        public GeographyPoint Location { get; set; }
    }
}
