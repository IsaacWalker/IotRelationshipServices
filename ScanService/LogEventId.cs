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
    }
}
