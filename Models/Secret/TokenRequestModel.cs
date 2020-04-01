using System;
using System.Collections.Generic;
using System.Text;
using Web.Iot.Models.Device;

namespace Web.Iot.Models.Secret
{
    public sealed class TokenRequestModel
    {
        public DeviceModel DeviceModel { get; set; }


        public Guid Nonce { get; set; }


        public string AttestationCypher { get; set; }
    }
}
