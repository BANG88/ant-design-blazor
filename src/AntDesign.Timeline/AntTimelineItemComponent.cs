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
        public string prefixCls = getPrefixCls("timeline");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add($"{prefixCls}-item")
               .Add($"{prefixCls}-item-pending", () => pending);

            /// dot class
            var c = new ClassNames();
            c.Add($"{prefixCls}-item-head")
                .Add($"{prefixCls}-item-head-custom", () => Dot != null)
                .Add($"{prefixCls}-item-head-{color}")
                ;
            DotClassName = c.ToString();

            /// dot style
            Regex rx = new Regex(@"blue|red|green");
            DotStyle = rx.IsMatch(color) ? "" : $"border-color: {color};";

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string color { get; set; } = "blue";

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
            get;
            set;
        }

        public string DotStyle
        {
            get; set;
        }

        [CascadingParameter(Name = "Timeline")] private AntTimelineComponent ParentTimeline { get; set; }
        protected override void OnInit()
        {
            ParentTimeline.addItem(this);
        }

    }
}
