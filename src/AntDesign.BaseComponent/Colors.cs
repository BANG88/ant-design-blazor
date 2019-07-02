using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AntDesign
{
    public class Colors
    {
        /// <summary>
        /// PresetColorTypes
        /// </summary>
        public static string[] PresetColorTypes = {
              "pink",
              "red",
              "yellow",
              "orange",
              "cyan",
              "green",
              "blue",
              "purple",
              "geekblue",
              "magenta",
              "volcano",
              "gold",
              "lime",
        };
        /// <summary>
        /// PresetColorRegex for tag
        /// </summary>
        public static Regex PresetColorRegex = new Regex(@"^(" + string.Join("|", PresetColorTypes) + ")(-inverse)?$");

        /// <summary>
        /// isPresetColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool isPresetColor(string color)
        {
            return PresetColorTypes.Contains(color);
        }
    }
}
