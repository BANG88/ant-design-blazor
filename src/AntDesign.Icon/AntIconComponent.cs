using AntDesign.BaseComponent;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AntDesign.Icon
{
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

        public AntIconDefinition Icon { get; set; }
       

        protected override Task OnParametersSetAsync()
        {
            var icon = AntIcons.all.Find(a => a.Name.Equals(this.Type));
            if (icon != null)
            {
                this.Icon = icon;
                //this.StateHasChanged();
            }
            return base.OnParametersSetAsync();
        }

    }
}
