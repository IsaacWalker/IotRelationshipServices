using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.DisplayService.Models
{
    public class StaticDisplayModel
    {
        public DateTime DateTime { get; set; }


        public List<DisplayDeviceModel> Devices { get; set; }
    }
}
