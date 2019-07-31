using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTimelineItem
    /// </summary>
    public class AntTimelineItemComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("timeline");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add($"{prefixCls}-item")
               .Add($"{prefixCls}-item-pending", () => pending);

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string color { get; set; }

        [Parameter]
        public bool pending { get; set; }

        [Parameter]
        public string position { get; set; }
        [Parameter]
        public RenderFragment Dot { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string DotClassName
        {
            get
            {
                var c = new ClassNames();
                c.Add($"{prefixCls}-item-head")
                    .Add($"{prefixCls}-item-head-custom", () => Dot != null)
                    .Add($"{prefixCls}-item-head-{color}")
                    ;
                return c.ToString();
            }
        }

        public string DotStyle
        {
            get
            {
                Regex rx = new Regex(@"/blue|red|green/");
                return rx.IsMatch(color) ? "" : $"border-color: {color};";
            }
        }
    }
}
