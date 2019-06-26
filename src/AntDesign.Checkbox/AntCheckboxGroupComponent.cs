using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace AntDesign
{
    using AntCheckboxValueType = OneOf<string, int, bool>;
    public class AntCheckboxOptionType
    {
        public OneOf<RenderFragment, string> label { get; set; }
        public AntCheckboxValueType value { get; set; }
        public bool disabled { get; set; }
        public EventCallback<UIChangeEventArgs> OnChange { get; set; }
    }

    public class AntCheckboxGroupContext
    {
        public EventCallback<AntCheckboxOptionType> toggleOption { get; set; }
        public AntCheckboxValueType value { get; set; }
        public bool disabled { get; set; }
        public string name { get; set; }
    }
    /// <summary>
    /// Base Component for AntCheckboxGroup
    /// </summary>
    public class AntCheckboxGroupComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("checkbox");

        private string groupPrefixCls => $"{prefixCls}-group";
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(groupPrefixCls);

            return base.OnParametersSetAsync();
        }

        [Parameter]
        public bool disabled { get; set; }

        [Parameter]
        public OneOf<List<AntCheckboxOptionType>, List<string>> options { get; set; }

        [Parameter]
        public string name { get; set; }

        [Parameter]
        public List<AntCheckboxValueType> value { get; set; }

        [Parameter]
        public List<AntCheckboxValueType> defaultValue { get; set; }

        [Parameter]
        public EventCallback<List<AntCheckboxValueType>> OnChange { get; set; }


        protected AntCheckboxGroupContext getChildContext()
        {
            return new AntCheckboxGroupContext
            {
                name = this.name,
                disabled = this.disabled,
            };
        }

        protected List<AntCheckboxOptionType> AllOptions
        {
            get
            {
                return this.options.Match(o => o, s => s.ConvertAll(option => new AntCheckboxOptionType
                {
                    label = option,
                    value = option,
                }));
            }
        }
    }
}
