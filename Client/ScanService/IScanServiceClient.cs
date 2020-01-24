/***************************************************
    IScanServiceClient.cs

    Isaac Walker
****************************************************/


using System.Threading.Tasks;

namespace Web.Iot.Client.ScanService
{
    /// <summary>
    /// Client for the Scan Service
    /// </summary>
    public interface IScanServiceClient
    {
        /// <summary>
        /// Gets count of scans
        /// </summary>
        /// <returns></returns>
        public Task<int> GetScanCountAsync();
    }
}
