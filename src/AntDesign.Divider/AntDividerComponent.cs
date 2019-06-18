using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Divider
{

    public static class AntDividerType
    {
        public const string Horizontal = "horizontal";

        public const string Vertical = "vertical";
    }

    public static class AntDividerOrientation
    {
        public const string Left = "left";
        public const string Right = "right";
        public const string Center = "center";
    }
    /// <summary>
    /// Base Component for AntDivider
    /// </summary>
    public class AntDividerComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("divider");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{Type}")
               .Add($"{prefixCls}-with-text{Orientation}", () => ChildContent != null)
               .Add($"{prefixCls}-dashed", () => Dashed)
               ;

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public string Type { get; set; } = AntDividerType.Horizontal;


        [Parameter]
        public string Orientation { get; set; } = AntDividerOrientation.Center;


        [Parameter]
        public bool Dashed { get; set; }


        [Parameter]
        protected RenderFragment ChildContent { get; set; }
    }
}
