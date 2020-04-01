using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Iot.APIGatewayService.Security
{
    public sealed class NonceStore : INonceStore
    {
        private static readonly byte _emptyData = 0;


        private readonly IDictionary<Guid, byte> _nonces 
            = new ConcurrentDictionary<Guid, byte>();


        public Guid CreateNewAsync()
        {
            Guid nonce = Guid.NewGuid();

            _nonces.Add(nonce, _emptyData);
            return nonce;
        }

        public bool Exists(Guid Nonce)
        {
            return _nonces.ContainsKey(Nonce);
        }

        public bool TryDeleteAsync(Guid Nonce)
        {
            bool present = Exists(Nonce);
            
            if(present)
            {
                _nonces.Remove(Nonce);
            }

            return present;
        }
    }
}
