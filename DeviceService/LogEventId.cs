/***************************************************
    LogEventId.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.Logging;

namespace Web.Iot.DeviceService
{
    public static class LogEventId
    {
        #region info

        /// <summary>
        /// Start of the create device request
        /// </summary>
        public static readonly EventId CreateDeviceStart = 0;


        /// <summary>
        /// End of the create device request
        /// </summary>
        public static readonly EventId CreateDeviceEnd = 1;


        /// <summary>
        /// Start of get device request
        /// </summary>
        public static readonly EventId GetDeviceStart = 2;


        /// <summary>
        /// End of the get device request
        /// </summary>
        public static readonly EventId GetDeviceEnd = 3;

        #endregion
    }
}
