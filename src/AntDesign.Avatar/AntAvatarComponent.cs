using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntAvatar
    /// </summary>
    public class AntAvatarComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("avatar");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-lg", () => size.Equals("large"))
               .Add($"{prefixCls}-sm", () => size.Equals("small"))
               .Add($"{prefixCls}-{shape}", () => !string.IsNullOrEmpty(shape))
               .Add($"{prefixCls}-image", () => !string.IsNullOrEmpty(src))
               .Add($"{prefixCls}-icon", () => !string.IsNullOrEmpty(icon))
               ;

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string src { get; set; }

        [Parameter]
        public string srcSet { get; set; }
        [Parameter]
        public string alt { get; set; }
        [Parameter]
        public string icon { get; set; }
        /// <summary>
        /// 'circle' | 'square'
        /// </summary>
        [Parameter]
        public string shape { get; set; } = "circle";

        /// <summary>
        /// 'large' | 'small' | 'default'
        /// </summary>
        [Parameter]
        public string size { get; set; } = "default";

        
    }
}
