using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisplayService.Models
{
    public sealed class DisplayDeviceModel
    {
        public string Name { get; set; }


        public double Latitude { get; set; }


        public double Longitude { get; set; }


        public double Rotation { get; set; }
    }

    public enum DeviceType
    {
        WIFI,
        BLUETOOTH
    }

}
