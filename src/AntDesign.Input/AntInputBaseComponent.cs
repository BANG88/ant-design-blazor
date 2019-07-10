using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign
{
    public class AntInputBaseComponent : AntBaseComponent
    {
        [Parameter]
        public string size { get; set; } = "default";

        [Parameter]
        public bool disabled { get; set; }

        [Parameter]
        public string value { get; set; }
        [Parameter]
        public string placeholder { get; set; }


        [Parameter]
        public RenderFragment AddonBefore { get; set; }

        [Parameter]
        public RenderFragment AddonAfter { get; set; }
        [Parameter]
        public RenderFragment Prefix { get; set; }
        [Parameter]
        public RenderFragment Suffix { get; set; }

        [Parameter]
        public bool allowClear { get; set; }
    }
}
