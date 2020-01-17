/***************************************************
    SettingModel.cs

    Isaac Walker
****************************************************/

namespace Web.Iot.Shared.Setting
{
    /// <summary>
    /// The model of an individual setting
    /// </summary>
    public class SettingModel
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }
    }
}
