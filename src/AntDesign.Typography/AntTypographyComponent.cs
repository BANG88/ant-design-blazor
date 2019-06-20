using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTypography
    /// </summary>
    public class AntTypographyComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("typography");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string ID { get; set; }

        [Parameter]
        public string Component { get; set; } = "article";

        [Parameter]
        protected RenderFragment ChildContent { get; set; }
    }
}
