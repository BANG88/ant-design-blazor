using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using AntDesign.BaseComponent;
using System.Threading.Tasks;

namespace AntDesign.Button
{

    public static class AntButtonType
    {
        public const string Default = "default";
        public const string Primary = "primary";
        public const string Ghost = "ghost";
        public const string Dashed = "dashed";
        public const string Danger = "danger";
        public const string Link = "link";
    }
    public class AntButtonComponent : AntBaseComponent
    {
        public AntButtonComponent()
        {
            ClassNames.Add(prefixCls);
        }

        /// <summary>
        /// Get prefixCls
        /// </summary>
        private string prefixCls
        {
            get
            {
                return getPrefixCls("btn");
            }
        }
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Add($"{prefixCls}-{Type}");
            return base.OnParametersSetAsync();
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private string _type;

        [Parameter]
        public string Type
        {
            get { return _type ?? AntButtonType.Default; }
            set
            {
                _type = value;
            }
        }

    }
}
