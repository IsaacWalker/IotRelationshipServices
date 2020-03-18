using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Iot.Models.GDPR;
using Web.Iot.Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    public class GetScanSubjectAccessResponse : Response
    {
        public readonly SubjectDataModel DataModel;


        public GetScanSubjectAccessResponse(SubjectDataModel dataModel, bool Success) : base(Success)
        {
            DataModel = dataModel;
        }
    }
}
