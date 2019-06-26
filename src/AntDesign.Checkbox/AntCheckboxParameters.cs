using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign
{
    public class AntCheckboxParameters : AntBaseComponent
    {
        private bool @checked;

        [Parameter]
        public string name { get; set; }
        [Parameter]
        public string id { get; set; }
        [Parameter]
        public string type { get; set; } = "checkbox";
        [Parameter]
        public bool defaultChecked { get; set; }


        [Parameter]
        public bool Checked { get => @checked || defaultChecked; set => @checked = value; }

        [Parameter]
        public bool disabled { get; set; }
        [Parameter]
        public bool readOnly { get; set; }
        [Parameter]
        public bool autoFocus { get; set; }

        [Parameter]
        public string value { get; set; }
    }
}
