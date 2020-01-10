using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Web.Iot.ScanService.MongoDB.Data;

namespace Web.Iot.ScanService.Models
{
    public class ScanBatchModel
    {
        /// <summary>
        /// Device Id
        /// </summary>
        [JsonProperty("device_id")]
        public long DeviceId { get; set; }


        /// <summary>
        /// The scans in the batch
        /// </summary>
        [JsonProperty("scans")]
        public List<Scan> Scans { get; set; }
    }
}
