using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.ScanService.MongoDB.Data
{
    /// <summary>
    /// MongoDB Serialization of LinearAcceleration
    /// </summary>
    public sealed class LinearAcceleration
    {
        /// <summary>
        /// Linear acceleration in X
        /// </summary>
        public float X { get; set; }


        /// <summary>
        /// Acceleration in Y
        /// </summary>
        public float Y { get; set; }


        /// <summary>
        /// Acceleration in Z
        /// </summary>
        public float Z { get; set; }
    }
}
