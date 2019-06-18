using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;

namespace AntDesign.Badge
{
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
