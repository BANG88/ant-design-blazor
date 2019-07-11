using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntSearch
    /// </summary>
    public class AntInputPasswordComponent : AntInputBaseComponent
    {
        protected string prefixCls = getPrefixCls("input-password");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{size}", () => !string.IsNullOrEmpty(size));

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public bool visibilityToggle { get; set; } = true;

        protected bool visible { get; set; }
    }
}
