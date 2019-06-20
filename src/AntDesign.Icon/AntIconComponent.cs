using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AntDesign
{

    public static class AntIconTheme
    {
        public const string Fill = "fill";
        public const string Outline = "outline";
    }
    public class AntIconComponent : AntBaseComponent
    {
        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public bool Spin { get; set; }

        [Parameter]
        public string Width { get; set; } = "1em";

        [Parameter]
        public string Height { get; set; } = "1em";

        [Parameter]
        public string Fill { get; set; } = "currentColor";

        [Parameter]
        public string Theme { get; set; } = AntIconTheme.Outline;

        public AntIconDefinition Icon { get; set; }

        protected override Task OnParametersSetAsync()
        {
            AntIconDefinition icon;

            AntIcons.icons.TryGetValue($"{this.Type}-{this.Theme}".ToLower(), out icon);

            if (icon != null)
            {
                this.Icon = icon;
            }
            return base.OnParametersSetAsync();
        }

    }
}
