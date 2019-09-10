/***************************************************
    LogScanAsync.cs

    Isaac Walker
****************************************************/

using System.Threading.Tasks;
using Shared.Message;

namespace Web.Iot.ScanService.MongoDB
{
    /// <summary>
    /// Log Scan Processor
    /// </summary>
    public sealed class LogScanAsync : IProcessor
        <LogScanRequest, LogScanResponse>
    {
        public async Task<LogScanResponse> Run(LogScanRequest Request)
        {
            //TODO
            throw new System.NotImplementedException();
        }
    }
}
