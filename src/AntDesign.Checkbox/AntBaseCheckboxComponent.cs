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
               .Add($"{prefixCls}-checked", () => Checked.GetValueOrDefault())
               .Add($"{prefixCls}-disabled", () => disabled)
               ;

            return base.OnParametersSetAsync();
        }
        [Parameter]
        public string prefixCls { get; set; } = "rc-checkbox";

        protected void OnChangeHandler(UIChangeEventArgs ev)
        {
            if (disabled)
            {
                return;
            }
            if (!this.Checked != null)
            {
                Checked = (bool)ev.Value;
            }
            if (this.checkboxGroup != null)
            {
                this.checkboxGroup.toggleOption(new AntCheckboxOptionType
                {
                    value = this.value,
                    label = this.ChildContent
                });
            }
            else
            {
                OnChange.InvokeAsync(ev);
            }
        }

    }
}
