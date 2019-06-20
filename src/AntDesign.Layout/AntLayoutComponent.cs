using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntLayout
    /// </summary>
    public class AntLayoutComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("layout");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
    }
}
