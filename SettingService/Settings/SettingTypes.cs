/***************************************************
    SettingTypes.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Iot.SettingService.Settings
{
    public class SettingType
    {
        public static string String = "System.String";


        public static string Double = "System.Double";


        public static string Integer = "System.Integer";


        public static string Boolean = "System.Boolean";


        public static readonly IDictionary<string, Func<string, bool>> ParseTable =
            new Dictionary<string, Func<string, bool>>()
            {
                {SettingType.String, new Func<string, bool>((name) => { return true; })},
                {SettingType.Double, new Func<string, bool>((name) => { return double.TryParse(name,out _); })},
                {SettingType.Integer, new Func<string, bool>((name) => { return int.TryParse(name,out _); })},
                {SettingType.Boolean, new Func<string, bool>((name) => { return bool.TryParse(name,out _); })},
            };

        public static ISet<string> ValidTypes = ParseTable.Keys.ToHashSet();
    }
}
