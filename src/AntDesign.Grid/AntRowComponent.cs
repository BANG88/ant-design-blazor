using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AntDesign.BaseComponent;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign.Grid
{

    public static class AntRowAligns
    {
        public const string Top = "top";
        public const string Middle = "middle";
        public const string Bottom = "bottom";
    }

    public static class AntRowJustify
    {
        public const string Start = "start";
        public const string End = "end";
        public const string Center = "center";
        public const string SpaceAround = "space-around";
        public const string SpaceBetween = "space-between";
    }

    /// <summary>
    /// Base Component for AntRow
    /// </summary>
    public class AntRowComponent : AntBaseComponent
    {

        private string prefixCls = getPrefixCls("row");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{Type}", () => hasType)
               .Add($"{prefixCls}-{Type}-{Justify}", () => hasType && !string.IsNullOrEmpty(Justify))
               .Add($"{prefixCls}-{Type}-{Align}", () => hasType && !string.IsNullOrEmpty(Align))
               ;

            return base.OnParametersSetAsync();
        }

        /// <summary>
        /// check type 
        /// </summary>
        private bool hasType => !string.IsNullOrEmpty(Type);

        [Parameter]
        public string Type { get; set; } = "flex";

        [Parameter]
        public string Align { get; set; }

        [Parameter]
        public string Justify { get; set; }

        [Parameter]
        public int Gutter { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}
