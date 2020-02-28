using FYPDataGenerator.ClusterGraph;
using FYPDataGenerator.Gowalla;
using FYPDataGenerator.Simulation;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Client.SettingService;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;
using Web.Iot.ScanService.Models;

namespace FYPDataGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("Reading Data");
            //  new GowallaConverter().Run();

            Console.WriteLine("Running Loadtest");
            RunLoadtestSimulation();
            Console.ReadKey();
        }



        private static void RunLoadtestSimulation()
        {
            
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            
            IDeviceServiceClient deviceServiceClient = new DeviceServiceClient(httpClientFactory);
            IScanServiceClient scanServiceClient = new ScanServiceClient(httpClientFactory);
            ISettingServiceClient settingServiceClient = new SettingServiceClient(httpClientFactory);

             IList<DeviceModel> TestDevices = FileParser.ReadTestDevices();         
             IList<ScanBatchModel> scanBatchModels = ScanServiceClient.CreateScanBatchModels(FileParser.ReadScanModel().GetRange(0, 10000),5).ToList();
            DeviceModel device = new DeviceModel() { Id = 1 };

            var wifiBleDevices = FileParser.ReadClusterDevices();
            IClusterGraphScanGenerator scanGenerator = new ClusterGraphScanGenerator();
            scanGenerator.Run(device, wifiBleDevices.Item1, wifiBleDevices.Item2);

             ISimulation<SimulationResult> loadTestSimulation = new LoadTestSimulation(
                 deviceServiceClient,
                 settingServiceClient,
                 scanServiceClient,
                 TestDevices,
                 scanBatchModels);

            ISimulation<SimulationResult> clusterInsertSimulation = new ClusterInsertSimulation(
                deviceServiceClient,
                settingServiceClient,
                scanServiceClient,
                scanGenerator,
                wifiBleDevices.Item1,
                wifiBleDevices.Item2);

            loadTestSimulation.Run();
        }

    }
}
