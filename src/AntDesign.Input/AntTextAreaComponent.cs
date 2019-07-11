using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTextArea
    /// </summary>
    public class AntTextAreaComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("input");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-disabled", () => disabled)
               ;

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string placeholder { get; set; }

        [Parameter]
        public bool disabled { get; set; }
        [Parameter]
        protected EventCallback<UIChangeEventArgs> OnChange { get; set; }
    }
}
