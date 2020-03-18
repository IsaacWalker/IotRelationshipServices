/***************************************************
    IScanServiceClient.cs

    Isaac Walker
****************************************************/


using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Iot.Models.GDPR;
using Web.Iot.ScanService.Models;

namespace Web.Iot.Client.ScanService
{
    /// <summary>
    /// Client for the Scan Service
    /// </summary>
    public interface IScanServiceClient : IServiceClient
    {
        /// <summary>
        /// Gets count of scans
        /// </summary>
        /// <returns></returns>
        public Task<int> GetScanCountAsync();


        /// <summary>
        /// Inserts a batch of scans
        /// </summary>
        /// <param name="scanBatch"></param>
        /// <returns></returns>
        public Task<bool> InsertScanBatchAsync(ScanBatchModel scanBatch);


        /// <summary>
        /// Gets the personal data of the scan service
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<SubjectDataModel> GetScanSubjectData(int deviceId);


        /// <summary>
        /// Erases the data of a subject in the scan service
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<bool> EraseSubjectData(int deviceId);
    }
}
