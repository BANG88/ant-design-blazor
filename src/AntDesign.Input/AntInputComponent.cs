﻿using System;
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
            ClassNames.Clear();

            return base.OnParametersSetAsync();
        }


        private string getInputClassName()
        {
            ClassNames classNames = new ClassNames();
            classNames
            .Add(prefixCls)
            .Add($"{prefixCls}-sm", () => size.Equals("small"))
            .Add($"{prefixCls}-lg", () => size.Equals("large"))
            .Add($"{prefixCls}-disabled", () => disabled)
            ;

            return classNames.Class;
        }
        protected string wrapperClassName
        {
            get => $"{this.prefixCls}-group";
        }

        protected string addonClassName
        {
            get => $"{wrapperClassName}-addon";
        }

        protected string getMergedGroupClassName()
        {
            ClassNames classNames = new ClassNames();
            classNames
            .Add($"{prefixCls}-group-wrapper")
            .Add($"{prefixCls}-group-wrapper-sm", () => size.Equals("small"))
            .Add($"{prefixCls}-group-wrapper-lg", () => size.Equals("large"))
            ;

            return $"{Class} {classNames.Class}".Trim();
        }
        protected string getMergedWrapperClassName()
        {
            ClassNames classNames = new ClassNames();
            classNames
            .Add($"{prefixCls}-wrapper")
            .Add($"{wrapperClassName}", () => AddonBefore != null || AddonAfter != null)
            ;

            return $"{classNames.Class}".Trim();
        }
        protected string getInputClass()
        {
            return $"{this.getInputClassName()}".Trim();
        }
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
    }
}
