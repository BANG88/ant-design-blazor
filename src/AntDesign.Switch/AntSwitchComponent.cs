using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{


    /// <summary>
    /// Base Component for AntSwitch
    /// </summary>
    public class AntSwitchComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("switch");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
                .Add($"{prefixCls}-checked", () => Checked.GetValueOrDefault())
               .Add($"{prefixCls}-disabled", () => disabled || loading)
               .Add($"{prefixCls}-loading", () => loading)
               .Add($"{prefixCls}-small", () => size.Equals("small"))
               ;

            return base.OnParametersSetAsync();
        }

        private bool? @checked;

        [Parameter]
        public bool defaultChecked { get; set; }


        [Parameter]
        public bool? Checked
        {
            get => @checked != null ? @checked : defaultChecked;
            set
            {
                @checked = value;
            }
        }

        [Parameter]
        public bool disabled { get; set; }



        [Parameter]
        public bool loading { get; set; }

        [Parameter]
        public string size { get; set; } = "default";
        [Parameter]
        public RenderFragment CheckedChildren { get; set; }



        [Parameter]
        public RenderFragment UnCheckedChildren { get; set; }

        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            if (disabled || loading)
            {
                return;
            }
            this.Checked = !this.Checked;
            OnChange.InvokeAsync(this.Checked.GetValueOrDefault());
        }
        [Parameter]
        protected EventCallback<bool> OnChange { get; set; }
    }
}
