using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntTag
    /// </summary>
    public class AntTagComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("tag");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-{color}", () => isPresetColor(color))
               .Add($"{prefixCls}-has-color", () => !string.IsNullOrEmpty(color) && !isPresetColor(color))
               .Add($"{prefixCls}-hidden", () => !visible)
               ;

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string color { get; set; }
        [Parameter]
        public bool closable { get; set; }

        [Parameter]
        public bool visible { get; set; } = true;

        private bool isPresetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return false;
            }
            return Colors.PresetColorRegex.IsMatch(color);
        }
        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            this.visible = false;
        }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string TagStyle
        {
            get
            {
                string backgroundColor = !string.IsNullOrEmpty(color) && !isPresetColor(color) ? $"background-color: {color}; " : string.Empty;
                return string.Concat(backgroundColor, style);
            }
        }
    }
}
