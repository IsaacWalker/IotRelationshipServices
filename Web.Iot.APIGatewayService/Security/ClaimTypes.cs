using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security
{
    /// <summary>
    /// Claims associated with a jwt token
    /// </summary>
    public static class ClaimTypes
    {
        public static readonly string WifiHardwareAddress = nameof(WifiHardwareAddress);


        public static readonly string Manufacturer = nameof(Manufacturer);


        public static readonly string DeviceModel = nameof(DeviceModel);
    }
}
