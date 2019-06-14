using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// html class helper copy from https://github.com/SamProf/MatBlazor/blob/master/src/MatBlazor/Helpers/ClassMapper.cs
/// </summary>
namespace AntDesign.BaseComponent
{
    public class ClassNames
    {
        private string _class;
        private bool _dirty = true;

        public string Class
        {
            get
            {
                if (_dirty)
                {
                    _class = string.Join(" ", map.Where(i => i.Value()).Select(i => i.Key()));
                }

                return _class;
            }
        }


        private Dictionary<Func<string>, Func<bool>> map = new Dictionary<Func<string>, Func<bool>>();


        public void MakeDirty()
        {
            _dirty = true;
        }

        public ClassNames Add(string name)
        {
            map.Add(() => name, () => true);
            return this;
        }


        public ClassNames Get(Func<string> funcName)
        {
            map.Add(funcName, () => true);
            return this;
        }

        public ClassNames GetIf(Func<string> funcName, Func<bool> func)
        {
            map.Add(funcName, func);
            return this;
        }

        public ClassNames If(string name, Func<bool> func)
        {
            map.Add(() => name, func);
            return this;
        }
    }
}
