using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign
{

    public static class AntRowAligns
    {
        public const string Top = "top";
        public const string Middle = "middle";
        public const string Bottom = "bottom";
    }

    public static class AntRowJustify
    {
        public const string Start = "start";
        public const string End = "end";
        public const string Center = "center";
        public const string SpaceAround = "space-around";
        public const string SpaceBetween = "space-between";
    }

    /// <summary>
    /// Base Component for AntRow
    /// </summary>
    public class AntRowComponent : AntBaseComponent
    {

        private string prefixCls = getPrefixCls("row");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{type}", () => hasType)
               .Add($"{prefixCls}-{type}-{justify}", () => hasType && !string.IsNullOrEmpty(justify))
               .Add($"{prefixCls}-{type}-{align}", () => hasType && !string.IsNullOrEmpty(align))
               ;

            return base.OnParametersSetAsync();
        }

        /// <summary>
        /// check type 
        /// </summary>
        private bool hasType => !string.IsNullOrEmpty(type);

        [Parameter]
        public string type { get; set; } = "flex";

        [Parameter]
        public string align { get; set; }

        [Parameter]
        public string justify { get; set; }

        [Parameter]
        public int gutter { get; set; }

        /// <summary>
        /// TODO: breakpoint
        /// </summary>
        /// <returns></returns>
        protected string getStyle()
        {
            var style = "";
            if (this.gutter > 0)
            {
                style = $"margin-left: -{this.gutter / 2}px;margin-right: {this.gutter / 2}px;";
            }
            return $"{style} {this.style}".Trim();
        }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
