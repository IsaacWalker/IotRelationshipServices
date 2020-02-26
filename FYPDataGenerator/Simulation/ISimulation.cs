using System;
using System.Collections.Generic;
using System.Text;

namespace FYPDataGenerator.Simulation
{
    public interface ISimulation<T>
        where T : SimulationResult
    {
        T Run();
    }
}
