/***************************************************
    LogEventId.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.Logging;

namespace Web.Iot.SettingService
{
    /// <summary>
    /// Log Event Ids for SettingService
    /// </summary>
    public static class LogEventId
    {
        #region Information

        /// <summary>
        /// Start of the Get Current Setting
        /// </summary>
        public static readonly EventId GetCurrentSettingStart = 0;


        /// <summary>
        /// End of the Get Current Setting
        /// </summary>
        public static readonly EventId GetCurrentSettingEnd = 1;


        /// <summary>
        /// Start of the Set Current Setting
        /// </summary>
        public static readonly EventId SetCurrentSettingStart = 2;


        /// <summary>
        /// End of the Set Current Setting
        /// </summary>
        public static readonly EventId SetCurrentSettingEnd = 3;


        /// <summary>
        /// Start of Get Setting by Id
        /// </summary>
        public static readonly EventId GetSettingByIdStart = 4;


        /// <summary>
        /// End of Get Setting by Id
        /// </summary>
        public static readonly EventId GetSettingByIdEnd = 5;

        #endregion
    }
}
