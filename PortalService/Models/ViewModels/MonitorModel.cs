/***************************************************
    monitorModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.PortalService.Models.ViewModels
{
    /// <summary>
    /// Model for Monitoring of services
    /// </summary>
    public class MonitorModel
    {
        public string SettingServiceHealth { get; set; }


        public string DeviceServiceHealth { get; set; }


        public string ScanServiceHealth { get; set; }


        public bool IsSettingServiceHealthy => SettingServiceHealth == ServiceHealth.Healthy;


        public bool IsDeviceServiceeHealthy => DeviceServiceHealth == ServiceHealth.Healthy;


        public bool IsScanServiceHealthy => ScanServiceHealth == ServiceHealth.Healthy;


        public int NumberOfDevices { get; set; }


        public int NumberOfScans { get; set; }


        public int NumberOfSettings { get; set; }
    }


    public static class ServiceHealth
    {
        public static readonly string Healthy = nameof(ServiceHealth.Healthy);


        public static readonly string UnHealthy = nameof(ServiceHealth.UnHealthy);
    }

}
