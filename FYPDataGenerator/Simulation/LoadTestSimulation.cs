using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Client.SettingService;
using Web.Iot.Models.Device;

namespace FYPDataGenerator.Simulation
{
    public sealed class LoadTestSimulation : SimulationBase<SimulationResult>
    {
        private List<DeviceModel> testDevices = new List<DeviceModel>();


        public LoadTestSimulation(
            IDeviceServiceClient deviceServiceClient,
            ISettingServiceClient settingServiceClient,
            IScanServiceClient scanServiceClient) 
            : base(deviceServiceClient, settingServiceClient, scanServiceClient)
        {

        }

        protected async override Task RunTest()
        {
            Console.WriteLine("Testing Service: Device Service with {0} requests", testDevices.Count);

            foreach(DeviceModel device in testDevices)
            {
                bool success = await m_deviceServiceClient.RegisterDeviceAsync(device) != -1;                
            }
        }
    }
}
