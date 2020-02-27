using System;
using System.Collections.Generic;
using System.Text;
using Web.Iot.Models.Device;
using Web.Iot.Models.MongoDB;

namespace FYPDataGenerator.ClusterGraph
{
    public interface IClusterGraphScanGenerator
    {
        public IList<ScanModel> Run(DeviceModel device, 
            IList<WifiDeviceModel> wifiDevices, 
            IList<BluetoothDeviceModel> bluetoothDevices,
            ClusterGraphSettings settings=null);
    }
}
