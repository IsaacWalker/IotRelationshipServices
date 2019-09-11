/***************************************************
    KinematicsModel.cs

    Isaac Walker
****************************************************/

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
        public LinearAccelerationModel Acceleration { get; set; }


        /// <summary>
        /// The location of the Scan
        /// </summary>
        public GPSLocationModel Location { get; set; }
    }
}
