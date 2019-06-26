using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntCardMeta
    /// </summary>
    public class AntCardMetaComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("cardmeta");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
    }
}
