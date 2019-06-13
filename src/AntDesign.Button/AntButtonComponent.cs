using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using AntDesign.BaseComponent;
using System.Threading.Tasks;

namespace AntDesign.Button
{

    public static class ButtonTypes
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

        }
        protected override Task OnParametersSetAsync()
        {
            var prefixCls = getPrefixCls("btn");

            ClassNames.Add(prefixCls).
                Add($"{prefixCls}-{Type}");

            return base.OnParametersSetAsync();
        }
        /// <summary>
        /// Inline label of Button.
        /// </summary>
        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private string _type;

        [Parameter]
        public string Type
        {
            get { return _type ?? ButtonTypes.Default; }
            set
            {
                _type = value;
                ClassNames.MakeDirty();
            }
        }

    }
}
