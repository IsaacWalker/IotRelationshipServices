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


        private readonly AndroidModel[] _AndroidModelData;


        private readonly Random _random;

        public GowallaConverter(string[] androidModelLines)
        {
            _AndroidModelData = CreateAndroidModelData(androidModelLines);
            _random = new Random();
        }


        public void Run(string[] Lines, string deviceFileName, string scanFileName)
        {
            List<GowallaCheckIn> CheckIns = new List<GowallaCheckIn>();

            IDictionary<int, DeviceModel> _currentDeviceModels = new Dictionary<int, DeviceModel>();
            IList<ScanModel> _scanModels = new List<ScanModel>();

            for (int i = 0; i < DATA_SIZE; i++)
            {
                string line = Lines[i];
                string[] items = line.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(items[0]);

                GowallaCheckIn CheckIn = new GowallaCheckIn()
                {
                    Id = id,
                    DateTime = DateTime.Parse(items[1]),
                    Latitude = double.Parse(items[2]),
                    Longitude = double.Parse(items[3]),
                    LocationId = int.Parse(items[4])
                };

                if (!_currentDeviceModels.ContainsKey(id))
                {
                    CheckIns.Add(CheckIn);
                    DeviceModel model = new DeviceModel()
                    {
                        Id = CheckIn.Id,
                        Model = GetFakeModel(),
                        BluetoothName = GetFakeBleName(),
                        MacAddress = GetFakeMacAddress(),
                        Manufacturer = GetFakeManufacturer()
                    };

                    _currentDeviceModels.Add(id, model);
                }

                ScanModel scanModel = new ScanModel()
                {
                    BluetoothDevices = new List<BluetoothDeviceModel>(),
                    WifiDevices = new List<WifiDeviceModel>(),
                    GlobalConfigurationId = 1,
                    Timestamp = CheckIn.DateTime.Ticks,
                    DeviceId = CheckIn.Id,
                    Kinematics = new KinematicsModel
                    {
                        Latitude = CheckIn.Latitude,
                        Longitude = CheckIn.Longitude
                    }
                };

                _scanModels.Add(scanModel);
                
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(deviceFileName))
            {
                foreach (var device in _currentDeviceModels.Values)
                {
                    string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                        device.Id, device.Model, device.MacAddress, device.Manufacturer, device.BluetoothName);

                    file.WriteLine(line);
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(scanFileName))
            {
                foreach (var scan in _scanModels)
                {
                    string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                        scan.DeviceId, scan.Timestamp, scan.Kinematics.Latitude, scan.Kinematics.Longitude,scan.GlobalConfigurationId);

                    file.WriteLine(line);
                }
            }

            Console.WriteLine("Found {0} devices", _currentDeviceModels.Count);
        }


        private string GetFakeModel()
        {

            int rand_indx = _random.Next(0, _AndroidModelData.Length);
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
            int rand_indx = _random.Next(0, _AndroidModelData.Length);
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
