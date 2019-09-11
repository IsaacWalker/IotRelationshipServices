/***************************************************
    ScanBatchModel.cs

    Isaac Walker
****************************************************/

using System.Collections.Generic;

namespace Web.Iot.ScanService.Models
{ 

    /// <summary>
    /// Represents a Batch of scans
    /// </summary>
    public sealed class ScanBatchModel
    {
        /// <summary>
        /// Devices Id
        /// </summary>
        public long DeviceId { get; set; }


        /// <summary>
        /// Scans
        /// </summary>
        public List<ScanModel> Scans { get; set; }
    }
}
