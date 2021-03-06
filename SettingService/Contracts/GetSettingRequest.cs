﻿/***************************************************
    GetSettingRequest.cs

    Isaac Walker
****************************************************/


using Web.Iot.Shared.Message;

namespace Web.Iot.SettingService.Contracts
{
    /// <summary>
    /// Request for getting a setting with an Id
    /// </summary>
    public class GetSettingRequest : Request
    {
        public readonly int Id;


        public GetSettingRequest(int id)
        {
            Id = id;
        }
    }
}
