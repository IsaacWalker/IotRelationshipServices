using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Iot.ScanService.Controllers;
using Web.Iot.ScanService.Models;
using Web.Iot.ScanService.MongoDB;
using Web.Iot.Shared.Message;

namespace ScanServiceTest
{
    [TestClass]
    public class ScanTests
    {
        [TestMethod]
        public async void Should_Return_OK()
        {
            Mock<IProcessor<LogScanRequest, LogScanResponse>> m_processor
                = new Mock<IProcessor<LogScanRequest, LogScanResponse>>();

            LogScanResponse ProcessorResponse = new LogScanResponse(true);
            m_processor.Setup(S => S.Run(It.IsAny<LogScanRequest>()))
                .Returns(Task.FromResult(ProcessorResponse));

            Mock<ILogger<ScanController>> logger = new Mock<ILogger<ScanController>>();
            logger.Setup(L => L.LogInformation(It.IsAny<string>()));
            logger.Setup(L => L.LogWarning(It.IsAny<string>()));

            ScanController Controller = new ScanController(m_processor.Object, logger.Object);

            ScanBatchModel model = new ScanBatchModel()
            {
                DeviceId = 1
            };

            IActionResult result = await Controller.Post(model);
            Assert.IsNotNull(result);
        }
    }
}
