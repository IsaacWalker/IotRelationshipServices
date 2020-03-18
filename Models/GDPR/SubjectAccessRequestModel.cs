using System;
using System.Collections.Generic;
using System.Text;
using Web.Iot.Models.Device;

namespace Web.Iot.Models.GDPR
{
    public class SubjectAccessRequestModel
    {
        /// <summary>
        /// Peronal data relationg to the device service
        /// </summary>
        public SubjectDataModel DeviceSubjectData { get; set; }


        /// <summary>
        /// Personal Data relating to the scan service
        /// </summary>
        public SubjectDataModel ScanSubjectData { get; set; }


        /// <summary>
        /// DateTime the request was issued
        /// </summary>
        public DateTime DateTimeOfRequest { get;  set; }
    }
}
