using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.BaseComponent
{
    public class AntBaseComponent : ComponentBase
    {
        /// <summary>
        /// Prefix class
        /// </summary>
        /// <param name="suffixCls"></param>
        /// <returns></returns>
        protected static string getPrefixCls(string suffixCls)
        {
            string prefixCls = "ant";

            return string.IsNullOrEmpty(suffixCls) ? prefixCls : $"{prefixCls}-{suffixCls}";
        }
        private ElementRef _ref;

        public ElementRef Ref
        {
            get { return _ref; }
            set { _ref = value; }
        }

        public ClassNames ClassNames { get; } = new ClassNames();
        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassNames.MakeDirty();
            }
        }


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                this.StateHasChanged();
            }
        }

        private string _class;
        private string _style;

        protected AntBaseComponent()
        {
            ClassNames.Add("");
        }

    }
}
