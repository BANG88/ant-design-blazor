using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntRadio
    /// </summary>
    public class AntRadioComponent : AntCheckboxParameters
    {
        protected string prefixCls = getPrefixCls("radio");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
              .Add($"{prefixCls}-wrapper")
                .Add($"{prefixCls}-wrapper-checked", () => Checked.GetValueOrDefault())
                .Add($"{prefixCls}-wrapper-disabled", () => disabled)
               ;

            return base.OnParametersSetAsync();
        }


        [CascadingParameter(Name = "radioGroup")]
        public AntCheckboxGroupContext radioGroup { get; set; }
        protected void OnChangeHandler(UIChangeEventArgs ev)
        {

            if (this.radioGroup != null)
            {
                this.radioGroup.toggleOption(new AntCheckboxOptionType
                {
                    value = this.value,
                    label = this.ChildContent
                });

            }

            OnChange.InvokeAsync(ev);
        }

    }
}
