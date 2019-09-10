using Shared.Message;
/***************************************************
    LogScanResponse.cs

    Isaac Walker
****************************************************/

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
