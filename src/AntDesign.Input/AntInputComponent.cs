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
    public class AntInputComponent : AntInputBaseComponent
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
        protected bool hasPrefixSuffix
        {
            get => Prefix != null || Suffix != null || allowClear;
        }
        protected string MergedGroupClassName
        {
            get
            {
                ClassNames classNames = new ClassNames();
                classNames
                .Add($"{prefixCls}-group-wrapper")
                .Add($"{prefixCls}-group-wrapper-sm", () => size.Equals("small"))
                .Add($"{prefixCls}-group-wrapper-lg", () => size.Equals("large"))
                ;

                return $"{Class} {classNames.Class}".Trim();
            }
        }

        protected string AffixWrapperCls
        {
            get
            {
                ClassNames classNames = new ClassNames();
                classNames
                .Add($"{prefixCls}-affix-wrapper")
                .Add($"{prefixCls}-affix-wrapper-sm", () => size.Equals("small"))
                .Add($"{prefixCls}-affix-wrapper-lg", () => size.Equals("large"))
                ;

                return $"{Class} {classNames.Class}".Trim();
            }
        }

        protected string MergedWrapperClassName
        {
            get
            {
                ClassNames classNames = new ClassNames();
                classNames
                .Add($"{prefixCls}-wrapper")
                .Add($"{wrapperClassName}", () => AddonBefore != null || AddonAfter != null)
                ;

                return $"{classNames.Class}".Trim();
            }
        }

        protected string InputClass => $"{this.getInputClassName()}".Trim();

    }
}
