using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using OneOf;
namespace AntDesign
{
    using AntCheckboxValueType = OneOf<string, int, bool>;

    public class AntCheckboxParameters : AntBaseComponent
    {
        private bool? @checked;

        [Parameter]
        public string name { get; set; }
        [Parameter]
        public string id { get; set; }
        [Parameter]
        public string type { get; set; } = "checkbox";
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
        public bool readOnly { get; set; }
        [Parameter]
        public bool autoFocus { get; set; }

        [Parameter]
        public AntCheckboxValueType value { get; set; } = "";
        [Parameter]
        protected EventCallback<UIChangeEventArgs> OnChange { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter(Name = "checkboxGroup")]
        public AntCheckboxGroupContext checkboxGroup { get; set; }

    }
}
