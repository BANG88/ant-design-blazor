using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    /// <summary>
    /// Base Component for AntSearch
    /// </summary>
    public class AntSearchComponent : AntInputBaseComponent
    {
        protected string prefixCls = getPrefixCls("input-search");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear();

            return base.OnParametersSetAsync();
        }

        protected string InputClassName
        {
            get
            {
                ClassNames classNames = new ClassNames();
                classNames
                    .Add(prefixCls)
                    .Add($"{prefixCls}-enter-button", () => hasEnterButton)
                    .Add($"{prefixCls}-{size}", () => hasEnterButton && !string.IsNullOrEmpty(size));

                return classNames.ToString();
            }
        }

        [Parameter]
        public EventCallback<string> onSearch { get; set; }

        [Parameter]
        public bool enterButton { get; set; }

        [Parameter]
        public string enterButtonText { get; set; }

        public bool hasEnterButton => !string.IsNullOrEmpty(enterButtonText) || enterButton;
        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            onSearch.InvokeAsync(value);
        }

    }
}
