using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;

namespace FYPDataGenerator.Gowalla
{
    public class GowallaConverter
    {
        private static readonly int DATA_SIZE = 100000;


        private readonly List<AndroidModel> _AndroidModelData;


        private readonly Random _random;

        public GowallaConverter()
        {
            _AndroidModelData = FileParser.ReadAndroidModelData();
            _random = new Random();
        }


        public void Run()
        {
            IDictionary<int, DeviceModel> _currentDeviceModels = new Dictionary<int, DeviceModel>();
            IList<ScanModel> _scanModels = new List<ScanModel>();

            List<GowallaCheckIn> CheckIns = FileParser.ReadGowallaCheckIns(DATA_SIZE);
            foreach (GowallaCheckIn CheckIn in CheckIns)
            {

                if (!_currentDeviceModels.ContainsKey(CheckIn.Id))
                {
                    
                    DeviceModel model = new DeviceModel()
                    {
                        Id = CheckIn.Id,
                        Model = GetFakeModel(),
                        BluetoothName = GetFakeBleName(),
                        MacAddress = GetFakeMacAddress(),
                        Manufacturer = GetFakeManufacturer()
                    };

                    _currentDeviceModels.Add(CheckIn.Id, model);
                }

                ScanModel scanModel = new ScanModel()
                {
                    BluetoothDevices = new List<BluetoothDeviceModel>(),
                    WifiDevices = new List<WifiDeviceModel>(),
                    GlobalConfigurationId = 1,
                    DateTime = CheckIn.DateTime,
                    DeviceId = CheckIn.Id,
                    Kinematics = new KinematicsModel
                    {
                        Latitude = CheckIn.Latitude,
                        Longitude = CheckIn.Longitude
                    }
                };

                _scanModels.Add(scanModel);
                
            }

            FileParser.WriteDevices(_currentDeviceModels.Values);

            FileParser.WriteScans(_scanModels);

            Console.WriteLine("Found {0} devices", _currentDeviceModels.Count);
            Console.WriteLine("Found {0} scans", _scanModels.Count);
        }


        private string GetFakeModel()
        {

            int rand_indx = _random.Next(0, _AndroidModelData.Count);
            return _AndroidModelData[rand_indx].Model;
        }


        private string GetFakeBleName()
        {
            return "Bluetooth";
        }


        private static string GetFakeMacAddress()
        {
            return Guid.NewGuid()
                .ToString()
                .ToUpperInvariant();
        }


        private string GetFakeManufacturer()
        {
            int rand_indx = _random.Next(0, _AndroidModelData.Count);
            return _AndroidModelData[rand_indx].Manufacturer;
        }


        private AndroidModel[] CreateAndroidModelData(string[] Lines)
        {
            List<AndroidModel> models = new List<AndroidModel>();
            for(int i = 1; i< Lines.Length;i++)
            {
                string[] data = Lines[i].Split(",");

                AndroidModel model = new AndroidModel
                { 
                    Model = data[0],
                    Manufacturer = data[2]        
                };

                models.Add(model);
            }

            return models.ToArray();
        }
    }
}
