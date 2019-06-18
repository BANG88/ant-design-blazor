using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Badge
{
    /// <summary>
    /// Base Component for AntBadge
    /// </summary>
    public class AntBadgeComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("badge");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }

    }
}
