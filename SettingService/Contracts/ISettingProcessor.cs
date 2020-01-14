﻿/***************************************************
    ISettingProcessor.cs

    Isaac Walker
****************************************************/

using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Processor for handling operations on settings
    /// </summary>
    public interface ISettingProcessor :
        IProcessor<Request, GetCurrentSettingsResponse>,
        IProcessor<SetCurrentSettingsRequest, SetCurrentSettingsResponse>
    {
    }
}
