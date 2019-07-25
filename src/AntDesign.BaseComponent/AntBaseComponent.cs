using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign
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

        protected ClassNames ClassNames { get; } = new ClassNames();

        private string _class;

        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
        [Parameter]
        public string Class
        {
            /// Combine customize classnames
            get { return $"{ClassNames.Class} {_class}".Trim(); }
            set { _class = value; }
        }

        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string style
        {
            get => _style;
            set
            {
                _style = value;
            }
        }

        private string _style;

        /// <summary>
        /// CaptureUnmatched Attributes
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        Dictionary<string, object> Attributes { get; set; }

    }
}
