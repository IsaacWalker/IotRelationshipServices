using FYPDataGenerator.ClusterGraph;
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
    public sealed class ClusterInsertSimulation : SimulationBase<SimulationResult>
    {
        private readonly IClusterGraphScanGenerator m_scanGenerator;


        private readonly IList<WifiDeviceModel> m_wifiDevices;


        private readonly IList<BluetoothDeviceModel> m_bluetoothDevices;


        public ClusterInsertSimulation(
            IDeviceServiceClient deviceServiceClient,
            ISettingServiceClient settingServiceClient,
            IScanServiceClient scanServiceClient,
            IClusterGraphScanGenerator scanGenerator, 
            IList<WifiDeviceModel> wifiDevices,
            IList<BluetoothDeviceModel> bluetoothDevices
            ) 

            : base(deviceServiceClient, settingServiceClient, scanServiceClient)
        {
            m_scanGenerator = scanGenerator;
            m_wifiDevices = wifiDevices;
            m_bluetoothDevices = bluetoothDevices;
        }


        protected override Task RunTest()
        {
            DeviceModel device = new DeviceModel() { Id = 1 };
            var scanModels = m_scanGenerator.Run(device, m_wifiDevices, m_bluetoothDevices);

            Console.WriteLine("Scan Models {0}", scanModels.Count);

            var batchModels = ScanServiceClient.CreateScanBatchModels(scanModels, 5);
            ServiceEndpointLoad<ScanBatchModel> load = new ServiceEndpointLoad<ScanBatchModel>("Cluster Data", batchModels,SB =>
                m_scanServiceClient.InsertScanBatchAsync(SB));

            return Task.CompletedTask;
        }
    }
}
