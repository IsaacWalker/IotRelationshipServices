using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;

namespace FYPDataGenerator
{
    public static class FileParser
    {
        private static readonly string DeviceFileName = "devices.txt";
        private static readonly string ScanFileName = "scans.txt";
        private static readonly string GowallaFileName = "Gowalla_totalCheckins.txt";
        private static readonly string AndroidModelsFileName = "androidModels.csv";
        private static readonly string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";
        private static readonly string WifiDevicesFileName = "cluster_wifi_devices.txt";
        private static readonly string BluetoothDeviceFileName = "cluster_bluetooth_devices.txt";

        public static void WriteScans(IList<ScanModel> models)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ScanFileName))
            {
                foreach (var scan in models)
                {
                    string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                        scan.DeviceId, scan.DateTime.ToString(DateTimeFormat), scan.Kinematics.Latitude, scan.Kinematics.Longitude, scan.GlobalConfigurationId);

                    file.WriteLine(line);
                }
            }
        }

        public static void WriteDevices(ICollection<DeviceModel> models)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(DeviceFileName))
            {
                foreach (var device in models)
                {
                    string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                        device.Id, device.Model, device.MacAddress, device.Manufacturer, device.BluetoothName);

                    file.WriteLine(line);
                }
            }
        }

        public static List<GowallaCheckIn> ReadGowallaCheckIns(int Max)
        {
            string[] GowallaLines = File.ReadAllLines(GowallaFileName);
            List<GowallaCheckIn> CheckIns = new List<GowallaCheckIn>();

            for (int i= 0;i < GowallaLines.Length && i < Max;i++)
            {
                string line = GowallaLines[i];
                string[] items = line.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                GowallaCheckIn CheckIn = new GowallaCheckIn()
                {
                    Id = int.Parse(items[0]),
                    DateTime = DateTime.Parse(items[1]),
                    Latitude = double.Parse(items[2]),
                    Longitude = double.Parse(items[3]),
                    LocationId = int.Parse(items[4])
                };

                CheckIns.Add(CheckIn);
            }

            return CheckIns;
        }

        public static List<AndroidModel> ReadAndroidModelData()
        {
            string[] Lines = File.ReadAllLines(AndroidModelsFileName);
            List<AndroidModel> models = new List<AndroidModel>();
            for (int i = 1; i < Lines.Length; i++)
            {
                string[] data = Lines[i].Split(",");

                AndroidModel model = new AndroidModel
                {
                    Model = data[0],
                    Manufacturer = data[2]
                };

                models.Add(model);
            }

            return models;
        }

        public static List<DeviceModel> ReadTestDevices()
        {
            List<DeviceModel> devices = new List<DeviceModel>();

            string[] Lines = File.ReadAllLines(DeviceFileName);

            for(int i =0; i<Lines.Length; i++)
            {
                string[] data = Lines[i].Split("\t");

                DeviceModel device = new DeviceModel
                {
                    Id = int.Parse(data[0]),
                    Model = data[1],
                    MacAddress = data[2],
                    Manufacturer = data[3],
                    BluetoothName = data[4]
                };

                devices.Add(device);
            }

            return devices;
        }

        public static List<ScanModel> ReadScanModel()
        {
            List<ScanModel> scans = new List<ScanModel>();

            string[] Lines = File.ReadAllLines(ScanFileName);

            foreach(string line in Lines)
            {
                string[] data = line.Split("\t");

                ScanModel scanModel = new ScanModel()
                { 
                    BluetoothDevices = new List<BluetoothDeviceModel>(),
                    Configuration = null,
                    WifiDevices = new List<WifiDeviceModel>(),
                    DeviceId = int.Parse(data[0]),
                    DateTime = DateTime.Parse(data[1]),
                    Kinematics = new KinematicsModel()
                    {
                        Latitude  = double.Parse(data[2]),
                        Longitude = double.Parse(data[3])
                    },
                    GlobalConfigurationId = int.Parse(data[4])  
                };

                scans.Add(scanModel);
            }

            return scans;
        }


        public static Tuple<List<WifiDeviceModel>, List<BluetoothDeviceModel>> ReadClusterDevices()
        {
            List<WifiDeviceModel> wifiDevices = new List<WifiDeviceModel>();

            string[] Lines = File.ReadAllLines(WifiDevicesFileName);

            foreach (string line in Lines)
            {
                string[] data = line.Split("\t");

                WifiDeviceModel bt = new WifiDeviceModel()
                {
                    BSSID = data[0],
                    SSID = data[1],
                    Capabilities = data[2],
                    VenueName = data[3],
                    OperatorFriendlyName = data[4],
                    Level = int.Parse(data[5]),
                    DateTime = DateTime.Parse(data[6])
                };

                wifiDevices.Add(bt);
            }

            Lines = File.ReadAllLines(BluetoothDeviceFileName);

            List<BluetoothDeviceModel> bluetoothDevices = new List<BluetoothDeviceModel>();

            foreach (string line in Lines)
            {
                string[] data = line.Split("\t");

                BluetoothDeviceModel bluetoothDeviceModel = new BluetoothDeviceModel()
                {
                    Name = data[0],
                    Type = data[1],
                    RSSI = int.Parse(data[2]),
                    PowerLevel = int.Parse(data[3]),
                    Address = data[4],
                    DateTime = DateTime.Parse(data[5])
                };

                bluetoothDevices.Add(bluetoothDeviceModel);
            }

            return new Tuple<List<WifiDeviceModel>, List<BluetoothDeviceModel>>(wifiDevices, bluetoothDevices);
        }
    }
}
