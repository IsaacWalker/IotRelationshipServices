using FYPDataGenerator.Gowalla;
using FYPDataGenerator.Simulation;
using Microsoft.Extensions.DependencyInjection;
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
            //Console.WriteLine("Reading Data");
            // new GowallaConverter().Run();

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
            IList<ScanBatchModel> scanBatchModels = CreateScanBatchModels(FileParser.ReadScanModel().GetRange(0, 10000),5).ToList();
                
            ISimulation<SimulationResult> loadTest = new LoadTestSimulation(
                deviceServiceClient,
                settingServiceClient,
                scanServiceClient,
                TestDevices,
                scanBatchModels);
            loadTest.Run();
            Console.WriteLine("Found {0} batches", scanBatchModels.Count);
        }


        private static IEnumerable<ScanBatchModel> CreateScanBatchModels(List<ScanModel> scanModels, int batchSize)
        {
            List<ScanBatchModel> scanBatchModels = new List<ScanBatchModel>();
            var groups = scanModels.GroupBy(S => S.DeviceId);
            
            foreach(var g in groups)
            {
                for(int i =0; i< g.Count(); i+=batchSize)
                {
                    yield return new ScanBatchModel()
                    {
                        DeviceId = g.Key,
                        Scans = g.ToList().GetRange(i, Math.Min(batchSize, g.Count() - i))
                    };
                }
            }

        }
    }
}
