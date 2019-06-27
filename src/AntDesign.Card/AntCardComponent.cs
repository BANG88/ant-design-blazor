using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntCard
    /// </summary>
    public class AntCardComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("card");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
                .Add(prefixCls)
                .Add($"{prefixCls}-loading", () => loading)
                .Add($"{prefixCls}-bordered", () => bordered);

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public bool loading { get; set; }

        [Parameter]
        public bool bordered { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public RenderFragment Extra { get; set; }

        [Parameter]
        public string headStyle { get; set; }

        [Parameter]
        public string bodyStyle { get; set; }

        [Parameter]
        public string id { get; set; }
    }
}
