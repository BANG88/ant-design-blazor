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
            ClassNames.Add($"{prefixCls}-{Type}")
                .If($"{prefixCls}-{Shape}", () => !string.IsNullOrEmpty(Shape))
                 .If($"{prefixCls}-background-ghost", () => Ghost)
                  .If($"{prefixCls}-block", () => Block)
                  .If($"{prefixCls}-loading", () => Loading);


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

        [Parameter]
        public string Shape { get; set; }
        [Parameter]
        public bool Ghost { get; set; }
        [Parameter]
        public bool Block { get; set; }
        [Parameter]
        public bool Loading { get; set; }

    }
}
