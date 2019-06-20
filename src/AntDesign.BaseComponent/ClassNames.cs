using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// html class helper
/// </summary>
namespace AntDesign
{
    public class ClassNames
    {
        public string Class => string.Join(" ", map.Where(i => i.Value()).Select(i => i.Key));

        private Dictionary<string, Func<bool>> map = new Dictionary<string, Func<bool>>();

        /// <summary>
        /// Clear all classnames before add new one.
        /// </summary>
        /// <returns></returns>
        public ClassNames Clear()
        {
            map.Clear();
            return this;
        }
        /// <summary>
        /// Add classname
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ClassNames Add(string name)
        {
            if (!map.ContainsKey(name))
            {
                map.Add(name, () => true);
            }
            return this;
        }
        /// <summary>
        /// Add classname if func is true.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public ClassNames Add(string name, Func<bool> func)
        {
            if (!map.ContainsKey(name))
            {
                map.Add(name, func);
            }
            return this;
        }
    }
}
