using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FYPDataGenerator.Simulation
{
    public sealed class ServiceEndpointLoad<T>
    {
        public readonly string Name;


        private readonly IList<T> Load;


        private readonly Func<T, Task<bool>> EndpointAction;


        public ServiceEndpointLoad(string name, IList<T> load, Func<T, Task<bool>> endpointAction)
        {
            Name = name;
            Load = load;
            EndpointAction = endpointAction;
        }

        public async Task Run()
        {
            int successes = 0;

            Stopwatch watch = new Stopwatch();

            watch.Start();

            foreach(T Item in Load)
            {
                bool success = await EndpointAction.Invoke(Item);
                if (success)
                    successes++;
            }

            watch.Stop();

            Console.WriteLine("Endpoint {0} finished with {1}/{2} {3}% and time {4} miliseconds.",
                Name, successes, Load.Count, (float)(successes / Load.Count) * 100, watch.ElapsedMilliseconds);
        }
    }
}
