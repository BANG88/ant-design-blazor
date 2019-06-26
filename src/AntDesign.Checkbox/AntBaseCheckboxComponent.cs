using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntBaseCheckbox
    /// </summary>
    public class AntBaseCheckboxComponent : AntCheckboxParameters
    {

        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls)
               .Add($"{prefixCls}-checked", () => Checked)
               .Add($"{prefixCls}-disabled", () => disabled)
               ;

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string prefixCls { get; set; } = "rc-checkbox";
        [Parameter]
        protected EventCallback<UIChangeEventArgs> OnChange { get; set; }
        protected void OnChangeHandler(UIChangeEventArgs ev)
        {
            if (disabled)
            {
                return;
            }
            Checked = (bool)ev.Value;
            OnChange.InvokeAsync(ev);
        }
    }
}
