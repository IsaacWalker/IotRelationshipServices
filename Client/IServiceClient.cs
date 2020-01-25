using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web.Iot.Client
{
    public interface IServiceClient
    {
        Task<bool> PingAsync();
    }
}
