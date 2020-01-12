/***************************************************
    Setting.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// A unique setting with a name, type and value
    /// </summary>
    public class Setting
    {
        public string Name { get; set; }


        public string Value { get; set; }


        public SettingTypes Type { get; set; }


        public static ISet<string> ValidTypes => ParseTable.Keys.ToHashSet();


        public static readonly IDictionary<string, Func<string, bool>> ParseTable =
            new Dictionary<string, Func<string, bool>>()
            {
                {"System.String", new Func<string, bool>((name) => { return true; })},
                {"System.Double", new Func<string, bool>((name) => { return double.TryParse(name,out _); })},
                {"System.Integer", new Func<string, bool>((name) => { return int.TryParse(name,out _); })},
                {"System.Boolean", new Func<string, bool>((name) => { return bool.TryParse(name,out _); })},
            };
    }
}
