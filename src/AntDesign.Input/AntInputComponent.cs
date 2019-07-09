using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntInput
    /// </summary>
    public class AntInputComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("input");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
            .Add(prefixCls);

            return base.OnParametersSetAsync();
        }


        private string getInputClassName()
        {
            ClassNames classNames = new ClassNames();
            classNames
            .Add($"{prefixCls}-sm", () => size.Equals("small"))
            .Add($"{prefixCls}-lg", () => size.Equals("large"))
            .Add($"{prefixCls}-disabled", () => disabled)
            ;

            return classNames.Class;
        }

        protected string getInputClass()
        {
            return $"{Class} {this.getInputClassName()}".Trim();
        }
        [Parameter]
        public string size { get; set; } = "default";

        [Parameter]
        public bool disabled { get; set; }

        [Parameter]
        public string value { get; set; }
        [Parameter]
        public string placeholder { get; set; }
    }
}
