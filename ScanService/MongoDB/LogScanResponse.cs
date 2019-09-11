/***************************************************
    LogScanResponse.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    /// <summary>
    /// Response to Log Scan
    /// </summary>
    public sealed class LogScanResponse : Response
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Success"></param>
        public LogScanResponse(bool Success) : base(Success)
        {

        }
    }
}
