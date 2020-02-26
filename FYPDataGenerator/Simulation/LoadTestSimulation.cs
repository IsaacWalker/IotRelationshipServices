using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Client.SettingService;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;
using Web.Iot.ScanService.Models;

namespace FYPDataGenerator.Simulation
{
    public sealed class LoadTestSimulation : SimulationBase<SimulationResult>
    {
        private readonly IList<DeviceModel> TestDevices;


        private readonly IList<ScanBatchModel> ScanBatches;


        public LoadTestSimulation(
            IDeviceServiceClient deviceServiceClient,
            ISettingServiceClient settingServiceClient,
            IScanServiceClient scanServiceClient,
            IList<DeviceModel> testDevices,
            IList<ScanBatchModel> scanBatches)        

            : base(deviceServiceClient, settingServiceClient, scanServiceClient)
        {
            TestDevices = testDevices;
            ScanBatches = scanBatches;
        }


        protected async override Task RunTest()
        {
            Console.WriteLine("Testing Service: Scan Service with {0} requests", ScanBatches.Count);

            var deviceEndpointTest = new ServiceEndpointLoad<DeviceModel>("Register Device", TestDevices, async (D) =>
            {
                return await m_deviceServiceClient.RegisterDeviceAsync(D) != -1;
            });

            //  await deviceEndpointTest.Run();

            var scanEndpointTest = new ServiceEndpointLoad<ScanBatchModel>("Insert Scan", ScanBatches, async S =>
            {
                return await m_scanServiceClient.InsertScanBatchAsync(S);
            });

            await scanEndpointTest.Run();
        }
    }
}
