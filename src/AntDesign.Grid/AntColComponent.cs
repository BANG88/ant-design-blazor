using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Grid
{
    using ColSpanType = OneOf<string, int>;
    public class AntColSize
    {
        public ColSpanType span { get; set; }
    }
    /// <summary>
    /// Base Component for AntCol
    /// </summary>
    public class AntColComponent : AntBaseComponent
    {
        protected OneOf<string, int> ColSpanType;
        private string prefixCls = getPrefixCls("col");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{Span.Value}", () => this.Span.Value != null);

            return base.OnParametersSetAsync();
        }


        [Parameter]
        public ColSpanType Span { get; set; }


        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
