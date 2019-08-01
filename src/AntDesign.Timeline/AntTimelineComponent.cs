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
        public string mode { get; set; } = "";

        [Parameter]
        public bool reverse { get; set; }

        [Parameter]
        public RenderFragment Pending { get; set; }

        [Parameter]
        public RenderFragment PendingDot { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected List<AntTimelineItemComponent> Items
        {
            get
            {
                if (reverse)
                {
                    return Enumerable.Reverse(_items).ToList();
                }
                return _items;
            }
        }

        protected string getPositionCls(AntTimelineItemComponent item, int index)
        {

            if (mode.Equals("alternate"))
            {
                if (item.position.Equals("right"))
                {
                    return $"{item.prefixCls}-item-right";
                }
                if (item.position.Equals("left"))
                {
                    return $"{item.prefixCls}-item-left";
                }
                return index % 2 == 0 ? $"{item.prefixCls}-item-left" : $"{item.prefixCls}-item-right";
            }
            if (mode.Equals("left"))
            {
                return $"{item.prefixCls}-item-left";
            }
            if (mode.Equals("right"))
            {
                return $"{item.prefixCls}-item-right";
            }
            if (item.position.Equals("right"))
            {
                return $"{item.prefixCls}-item-right";
            }
            return "";
        }

        protected string getLastCls(int index)
        {
            string lastCls = $"{prefixCls}-item-last";

            return !reverse && Pending != null ? index.Equals(count - 2) ? lastCls : "" : index.Equals(count - 1) ? lastCls : "";

        }
        private List<AntTimelineItemComponent> _items { get; set; } = new List<AntTimelineItemComponent>() { };
        private int count { get; set; }
        public void addItem(AntTimelineItemComponent item)
        {
            Console.WriteLine(Items);
            if (item == null || !item.GetType().ToString().Equals("AntDesign.AntTimelineItem"))
            {
                return;
            }
            count++;
            _items.Add(item);
            StateHasChanged();
        }
        protected int index = 0;

    }
}
