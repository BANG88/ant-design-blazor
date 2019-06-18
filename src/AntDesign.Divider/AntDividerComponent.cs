using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;

namespace AntDesign.Divider
{
    public class AntDividerComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("divider");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
    }
}
