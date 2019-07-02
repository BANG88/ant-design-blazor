using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTypographyParagraph
    /// </summary>
    public class AntTypographyParagraphComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("typographyparagraph");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
    }
}
