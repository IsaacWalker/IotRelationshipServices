/***************************************************
    LogEventId.cs

    Isaac Walker
****************************************************/

using Microsoft.Extensions.Logging;

namespace Web.Iot.PortalService
{
    public static class LogEventId
    {
        #region info

        /// <summary>
        /// Start of the Get in HomeController
        /// </summary>
        public static readonly EventId IndexGetStart = 0;


        /// <summary>
        /// End of the Get in HomeController
        /// </summary>
        public static readonly EventId IndexGetEnd = 1;


        /// <summary>
        /// Start of save config in HomeController
        /// </summary>
        public static readonly EventId SaveConfigStart = 2;


        /// <summary>
        /// End of save config in HomeController
        /// </summary>
        public static readonly EventId SaveConfigEnd = 3;

        #endregion
    }
}
