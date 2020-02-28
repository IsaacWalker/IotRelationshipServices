using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;

namespace FYPDataGenerator.ClusterGraph
{
    public class ClusterGraphScanGenerator : IClusterGraphScanGenerator
    {
        private static readonly ClusterGraphSettings s_defaultSettings = new ClusterGraphSettings()
        {
            Clusters = new List<Cluster>()
            {
                new Cluster() { ClusterTimeMean = DateTime.Parse("09:30:00"), ClusterTimeStandardDeviation = TimeSpan.FromMinutes(20.00) },
                new Cluster() { ClusterTimeMean = DateTime.Parse("17:30:00"), ClusterTimeStandardDeviation = TimeSpan.FromMinutes(30.00) }
            },
            ActivePeriods = new List<Tuple<DateTime, TimeSpan>>()
            {
                new Tuple<DateTime, TimeSpan>(DateTime.Parse("08:00:00"), TimeSpan.FromHours(3.0)),
                new Tuple<DateTime, TimeSpan>(DateTime.Parse("16:30:00"), TimeSpan.FromHours(2.0))
            },
            ScanningDuration = TimeSpan.FromMinutes(4.0),
            StartDate = DateTime.Now,
            EndDate = DateTime.Now + TimeSpan.FromDays(7.0),
        };


        public IList<ScanModel> Run(DeviceModel device, 
            IList<WifiDeviceModel> wifiDevices, 
            IList<BluetoothDeviceModel> bluetoothDevices,
            ClusterGraphSettings settings = null)
        {
            if(settings == null)
            {
                settings = s_defaultSettings;
            }

            IList<ScanModel> scanModels = new List<ScanModel>();

            IDictionary<string, int> MACClusterMap = new Dictionary<string, int>();

            /// Go though each device and randomly assign them to a cluster
            foreach(var wifiDevice in wifiDevices)
            {
                int Cluster = 1;
                MACClusterMap.Add(wifiDevice.BSSID, Cluster);
            }

            foreach(var bluetoothDevice in bluetoothDevices)
            {
                int Cluster = 1;
                MACClusterMap.Add(bluetoothDevice.Address, Cluster);
            }


            /// Go Through each day, incrementing in duration, assign the devices that should be found  
            /// at that time interval, according to a normal distrubution.
            for(DateTime currentDay = settings.StartDate.Date; 
                currentDay < settings.EndDate.Date; 
                currentDay += TimeSpan.FromDays(1))
            {
                foreach(var period in settings.ActivePeriods)
                {
                    DateTime periodStartTime = currentDay + period.Item1.TimeOfDay;

                    for (DateTime currentDateTime = periodStartTime;
                        currentDateTime < periodStartTime + period.Item2;
                        currentDateTime += settings.ScanningDuration)
                    {
                        ScanModel scanModel = new ScanModel()
                        {
                            DeviceId = device.Id,
                            DateTime = currentDateTime,
                            BluetoothDevices = bluetoothDevices.Where(B =>
                                 IsInCluster(settings.Clusters[MACClusterMap[B.Address]], currentDateTime)).ToList(),
                            WifiDevices = wifiDevices.Where(W =>
                             IsInCluster(settings.Clusters[MACClusterMap[W.BSSID]], currentDateTime)).ToList(),
                            Configuration = null,
                            GlobalConfigurationId = 1,
                            Kinematics = new KinematicsModel()
                            { 
                                
                            }
                        };

                        scanModels.Add(scanModel);
                    }               
                }
            }

            return scanModels;
        }

        private bool IsInCluster(Cluster cluster, DateTime dateTime)
        {
            return cluster.ClusterTimeMean.Subtract(dateTime).TotalMinutes < 30;
        }

        
    }
}
