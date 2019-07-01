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
        public bool? disabled { get; set; }
        public EventCallback<UIChangeEventArgs> OnChange { get; set; }
    }

    public class AntCheckboxGroupContext
    {
        public Action<AntCheckboxOptionType> toggleOption { get; set; }
        public List<AntCheckboxValueType> value { get; set; }
        public bool disabled { get; set; }
        public string name { get; set; }
        public Action<AntCheckboxValueType> registerValue { get; set; }
        public Action<AntCheckboxValueType> cancelValue { get; set; }

    }
    /// <summary>
    /// Base Component for AntCheckboxGroup
    /// </summary>
    public class AntCheckboxGroupComponent : AntBaseComponent
    {
        private string prefixCls = getPrefixCls("checkbox");

        protected string groupPrefixCls => $"{prefixCls}-group";
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(groupPrefixCls);

            return base.OnParametersSetAsync();
        }
        /// <summary>
        /// disabled
        /// </summary>
        [Parameter]
        public bool disabled { get; set; }

        [Parameter]
        public OneOf<List<AntCheckboxOptionType>, List<string>> options { get; set; }

        [Parameter]
        public string name { get; set; }


        /// <summary>
        /// value
        /// </summary>
        private List<AntCheckboxValueType> value1;

        [Parameter]
        public List<AntCheckboxValueType> value { get => value1 ?? defaultValue; set => value1 = value; }


        /// <summary>
        /// default value
        /// </summary>
        [Parameter]
        public List<AntCheckboxValueType> defaultValue { get; set; }

        /// <summary>
        /// OnChange
        /// </summary>
        [Parameter]
        public EventCallback<List<AntCheckboxValueType>> OnChange { get; set; }

        protected bool hasChecked(AntCheckboxValueType value)
        {
            return this.value.Contains(value);
        }
        /// <summary>
        /// local value
        /// </summary>
        private List<AntCheckboxValueType> registeredValues = new List<AntCheckboxValueType> { };
        private void registerValue(AntCheckboxValueType value)
        {
            // Only add if its not existing
            if (!this.registeredValues.Contains(value))
            {
                this.registeredValues.Add(value);
            }

        }
        private void cancelValue(AntCheckboxValueType value)
        {
            this.registeredValues.Remove(value);
        }

        private void toggleOption(AntCheckboxOptionType option)
        {
            if (this.value.Contains(option.value))
            {
                this.value.Remove(option.value);
            }
            else
            {
                this.value.Add(option.value);
            }

            var v = this.value.Where(x => this.registeredValues.Contains(x)).ToList();

            this.OnChange.InvokeAsync(v);
        }

        /// <summary>
        /// child context
        /// </summary>
        /// <returns></returns>
        protected AntCheckboxGroupContext getChildContext()
        {
            return new AntCheckboxGroupContext
            {
                name = this.name,
                disabled = this.disabled,

                registerValue = this.registerValue,
                cancelValue = this.cancelValue,
                toggleOption = this.toggleOption,
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
