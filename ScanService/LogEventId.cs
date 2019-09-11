/***************************************************
    LogEventId.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.Logging;

namespace Web.Iot.ScanService
{
    /// <summary>
    /// Event Ids for the Logging
    /// </summary>
    public static class LogEventId
    {
        #region Information

        /// <summary>
        /// Start of the Post in ScanController
        /// </summary>
        public static readonly EventId ScanPostStart = 0;


        /// <summary>
        /// End of the post in the ScanController
        /// </summary>
        public static readonly EventId ScanPostEnd = 1;


        /// <summary>
        /// Start of the Post to ScanBatch
        /// </summary>
        public static readonly EventId ScanBatchPostStart = 2;


        /// <summary>
        /// End of the Post to ScanBatch
        /// </summary>
        public static readonly EventId ScanBatchPostEnd = 3;


        /// <summary>
        /// Start of Logging scan into MongoDB
        /// </summary>
        public static readonly EventId LogScanStart = 4;


        /// <summary>
        /// Successful Scan logged into MongoDB
        /// </summary>
        public static readonly EventId LogScanSuccess = 5;

        #endregion

        #region Error


        /// <summary>
        /// Error when logging scan into MongoDB
        /// </summary>
        public static readonly EventId LogScanError = 100;

        #endregion
    }
}
