using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntCheckbox
    /// </summary>
    public class AntCheckboxComponent : AntCheckboxParameters
    {
        protected string prefixCls = getPrefixCls("checkbox");

        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add($"{prefixCls}-wrapper")
                .Add($"{prefixCls}-wrapper-checked", () => Checked.GetValueOrDefault())
                .Add($"{prefixCls}-wrapper-disabled", () => disabled)
               ;

            return base.OnParametersSetAsync();
        }
        protected override Task OnAfterRenderAsync()
        {
            if (this.checkboxGroup != null)
            {
                this.checkboxGroup.registerValue(this.value);
                this.name = this.checkboxGroup.name;
            }
            return base.OnAfterRenderAsync();
        }

        [Parameter]
        public bool indeterminate { get; set; }

        [CascadingParameter(Name = "checkboxGroup")]
        public AntCheckboxGroupContext checkboxGroup { get; set; }
        protected void OnChangeHandler(UIChangeEventArgs ev)
        {
           
            if (this.checkboxGroup != null)
            {
                this.checkboxGroup.toggleOption(new AntCheckboxOptionType
                {
                    value = this.value,
                    label = this.ChildContent
                });

            }

            OnChange.InvokeAsync(ev);
        }


    }
}
