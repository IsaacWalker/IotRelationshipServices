/***************************************************
    SettingTypes.cs

    Isaac Walker
****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Iot.SettingService.Settings
{
    /// <summary>
    /// Represents the valid types permitted in settings
    /// </summary>
    public class SettingType
    {
        /// <summary>
        /// String type
        /// </summary>
        public static string String = "System.String";


        /// <summary>
        /// Double type
        /// </summary>
        public static string Double = "System.Double";


        /// <summary>
        /// Integer type
        /// </summary>
        public static string Integer = "System.Integer";


        /// <summary>
        /// Boolean type
        /// </summary>
        public static string Boolean = "System.Boolean";


        /// <summary>
        /// Table to check if the string value is valid given a type
        /// </summary>
        public static readonly IDictionary<string, Func<string, bool>> ParseTable =
            new Dictionary<string, Func<string, bool>>()
            {
                {SettingType.String, new Func<string, bool>((name) => { return true; })},
                {SettingType.Double, new Func<string, bool>((name) => { return double.TryParse(name,out _); })},
                {SettingType.Integer, new Func<string, bool>((name) => { return int.TryParse(name,out _); })},
                {SettingType.Boolean, new Func<string, bool>((name) => { return bool.TryParse(name,out _); })},
            };


        /// <summary>
        /// Enumerable valid types
        /// </summary>
        public static ISet<string> ValidTypes = ParseTable.Keys.ToHashSet();
    }
}
