using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign
{



    public class AntButtonGroupComponent : AntBaseComponent
    {

        /// <summary>
        /// Get prefixCls
        /// </summary>
        private string prefixCls = getPrefixCls("btn-group");

        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
                .Add(prefixCls)
                 .Add($"{prefixCls}-{SizeCls}", () => !string.IsNullOrEmpty(SizeCls));


            return base.OnParametersSetAsync();
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private string _size;

        [Parameter]
        public string size
        {
            get { return _size ?? AntButtonSize.Default; }
            set
            {
                _size = value;
            }
        }

       
        /// <summary>
        /// Size cls
        /// </summary>
        protected string SizeCls
        {
            get
            {
                var sizeCls = "";
                switch (size)
                {
                    case AntButtonSize.Large:
                        sizeCls = "lg";
                        break;
                    case AntButtonSize.Small:
                        sizeCls = "sm";
                        break;
                    default:
                        break;
                }
                return sizeCls;
            }
        }

    }
}
