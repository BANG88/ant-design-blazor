using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Grid
{
    /// <summary>
    /// Base Component for AntRow
    /// </summary>
    public class AntRowComponent : AntBaseComponent
    {
        protected OneOf<string, int> ColSpanType;
        private string prefixCls = getPrefixCls("row");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{Type}", () =>!string.IsNullOrEmpty(Type));

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public string Type { get; set; } = "flex";
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
