using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security
{
    public interface INonceStore
    {
        public Guid CreateNewAsync();

        public bool Exists(Guid Nonce);

        public bool TryDeleteAsync(Guid Nonce);
    }
}
