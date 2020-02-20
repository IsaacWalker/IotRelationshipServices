using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Web.Iot.Shared.MongoDB;

namespace Web.Iot.ScanService.Models
{
    public class ScanBatchModel
    {
        /// <summary>
        /// Device Id
        /// </summary>
        public long DeviceId { get; set; }


        /// <summary>
        /// The scans in the batch
        /// </summary>
        public List<Scan> Scans { get; set; }
    }
}
