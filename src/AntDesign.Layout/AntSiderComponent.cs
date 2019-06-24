using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntContent
    /// </summary>
    public class AntSiderComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("layout-sider");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-collapsed", () => this.collapsed)
               ;

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }


        [Parameter]
        public string width { get; set; } = "200px";

        [Parameter]
        public string collapsedWidth { get; set; } = "80px";


        [Parameter]
        public bool defaultCollapsed { get; set; }

        [Parameter]
        public bool collapsed { get; set; }
        [Parameter]
        public bool collapsible { get; set; }

        protected string getStyle()
        {
            var s = $"{Style} flex: 0 0 {this.siderWidth};max-width:{this.siderWidth};min-width:{this.siderWidth};width:{this.siderWidth};";
            return s;
        }
        public string siderWidth => this.collapsed ? this.collapsedWidth : this.width;


    }
}
