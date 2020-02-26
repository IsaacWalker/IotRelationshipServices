using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Iot.Client.DeviceService;
using Web.Iot.Client.ScanService;
using Web.Iot.Client.SettingService;

namespace FYPDataGenerator.Simulation
{
    public abstract class SimulationBase<T> : ISimulation<T>
        where T : SimulationResult
    {
        /// <summary>
        /// Device Service
        /// </summary>
        protected internal readonly IDeviceServiceClient m_deviceServiceClient;


        /// <summary>
        /// SettingService
        /// </summary>
        protected internal readonly ISettingServiceClient m_settingServiceClient;


        /// <summary>
        /// Scan Service
        /// </summary>
        protected internal readonly IScanServiceClient m_scanServiceClient;


        internal SimulationBase(
            IDeviceServiceClient deviceServiceClient,
            ISettingServiceClient settingServiceClient,
            IScanServiceClient scanServiceClient
            )
        {
            m_deviceServiceClient = deviceServiceClient;
            m_scanServiceClient = scanServiceClient;
            m_settingServiceClient = settingServiceClient;
        }


        protected virtual void Setup()
        {

        }


        protected abstract Task RunTest();


        protected virtual void Cleanup()
        {

        }


        public T Run()
        {
            Setup();
            RunTest();
            Cleanup();
            return default;
        }
    }
}
