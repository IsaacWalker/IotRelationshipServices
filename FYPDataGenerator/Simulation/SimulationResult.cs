using System;
using System.Collections.Generic;
using System.Text;

namespace FYPDataGenerator.Simulation
{
    public abstract class SimulationResult
    {
        public readonly long Time;

        public SimulationResult(long time)
        {
            Time = time;
        }
    }
}
