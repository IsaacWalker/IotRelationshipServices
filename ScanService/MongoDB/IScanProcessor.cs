﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    public interface IScanProcessor :
        IProcessor<LogScanRequest, LogScanResponse>,
        IProcessor<GetScanCountRequest, GetScanCountResponse>,
        IProcessor<GetScanSubjectAccessRequest, GetScanSubjectAccessResponse>,
        IProcessor<EraseSubjectDataRequest, EraseSubjectDataResponse>
    {
    }
}
