using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Grid
{
    using AntColSpanType = OneOf<string, int>;

    public class AntColSize
    {
        public AntColSpanType span { get; set; }
        public AntColSpanType order { get; set; }

        public AntColSpanType offset { get; set; }

        public AntColSpanType push { get; set; }

        public AntColSpanType pull { get; set; }

    }
    /// <summary>
    /// Base Component for AntCol
    /// </summary>
    public class AntColComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("col");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{span.Value}", () => this.span.Value != null)
               .Add($"{prefixCls}-order-{order.Value}", () => this.order.Value != null)
               .Add($"{prefixCls}-offset-{offset.Value}", () => this.offset.Value != null)
               .Add($"{prefixCls}-push-{push.Value}", () => this.push.Value != null)
               .Add($"{prefixCls}-pull-{pull.Value}", () => this.pull.Value != null)
               ;

            this.addSizeClass();

            return base.OnParametersSetAsync();
        }
        private void addSizeClass()
        {
            string[] sizes = { "xs", "sm", "md", "lg", "xl", "xxl" };
            var fileds = typeof(AntColComponent).GetFields().ToList();
            foreach (var size in sizes)
            {
                AntColSize antColSize = new AntColSize();
                var maybeXs = fileds.Find(f => f.Name.Equals(size));

                if (maybeXs == null)
                {
                    continue;
                }

                var oneOfX = (OneOf<AntColSpanType, AntColSize>)maybeXs.GetValue(typeof(AntColComponent));

                oneOfX.Switch(cspan =>
                {
                    antColSize.span = cspan;
                }, csize =>
                {
                    antColSize = csize;
                });

                ClassNames
                    .Add($"{prefixCls}-{size}-{antColSize.span}", () => antColSize.span.Value != null)
                    .Add($"{prefixCls}-{size}-order-{antColSize.order}", () => antColSize.order.Value != null)
                    .Add($"{prefixCls}-{size}-offset-{antColSize.offset}", () => antColSize.offset.Value != null)
                    .Add($"{prefixCls}-{size}-push-{antColSize.push}", () => antColSize.push.Value != null)
                    .Add($"{prefixCls}-{size}-pull-{antColSize.pull}", () => antColSize.pull.Value != null)
                    ;
            }
        }
        /// <summary>
        /// get style if gutter provide
        /// </summary>
        /// <returns></returns>
        protected string getStyle()
        {
            var style = "";
            if (this.gutter > 0)
            {
                style = $"padding-left: {this.gutter / 2}px;padding-right: {this.gutter / 2}px;";
            }
            return $"{style} {this.Style}".Trim();
        }

        [Parameter]
        public AntColSpanType span { get; set; }

        [Parameter]
        public AntColSpanType order { get; set; }

        [Parameter]
        public AntColSpanType offset { get; set; }

        [Parameter]
        public AntColSpanType push { get; set; }

        [Parameter]
        public AntColSpanType pull { get; set; }

        [Parameter]
        public OneOf<AntColSpanType, AntColSize> xs { get; set; }

        [Parameter]
        public OneOf<AntColSpanType, AntColSize> sm { get; set; }

        [Parameter]
        public OneOf<AntColSpanType, AntColSize> md { get; set; }

        [Parameter]
        public OneOf<AntColSpanType, AntColSize> lg { get; set; }

        [Parameter]
        public OneOf<AntColSpanType, AntColSize> xl { get; set; }
        [Parameter]
        public OneOf<AntColSpanType, AntColSize> xxl { get; set; }

        [CascadingParameter(Name = "gutter")]
        public int gutter { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
