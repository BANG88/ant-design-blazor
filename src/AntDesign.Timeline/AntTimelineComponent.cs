using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTimeline
    /// </summary>
    public class AntTimelineComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("timeline");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-pending", () => Pending != null)
               .Add($"{prefixCls}-reverse", () => reverse)
               .Add($"{prefixCls}-{mode}", () => !string.IsNullOrEmpty(mode))
               ;

            return base.OnParametersSetAsync();
        }

        /// <summary>
        /// 'left' | 'alternate' | 'right'
        /// </summary>
        [Parameter]
        public string mode { get; set; }

        [Parameter]
        public bool reverse { get; set; }

        [Parameter]
        public RenderFragment Pending { get; set; }

        [Parameter]
        public RenderFragment PendingDot { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected List<AntTimelineItemComponent> items { get; set; } = new List<AntTimelineItemComponent>() { };

        public void addItem(AntTimelineItemComponent item)
        {
            items.Add(item);
            StateHasChanged();
        }
    }
}
