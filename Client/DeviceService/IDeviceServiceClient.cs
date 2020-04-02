/***************************************************
    IDeviceServiceClient.cs

    Isaac Walker
****************************************************/


using System;
using System.Threading.Tasks;
using Web.Iot.Models.Device;
using Web.Iot.Models.GDPR;

namespace Web.Iot.Client.DeviceService
{
    /// <summary>
    /// Client for the Device Service
    /// </summary>
    public interface IDeviceServiceClient : IServiceClient
    {
        /// <summary>
        /// Gets the count of the device
        /// </summary>
        /// <returns></returns>
        public Task<int> GetDeviceCountAsync();


        /// <summary>
        /// Registers a Device
        /// </summary>
        /// <returns></returns>
        public Task<bool> RegisterDeviceAsync(DeviceModel device);


        /// <summary>
        /// Gets the device personal data for a SAR
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<SubjectDataModel> GetDeviceSubjectData(Guid deviceId);


        /// <summary>
        /// Erases the data of a subject for the device service
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<bool> EraseSubjectData(Guid deviceId);
    } 
}
