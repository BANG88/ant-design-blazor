using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign
{

    /// <summary>
    /// Button type
    /// </summary>
    public static class AntButtonType
    {
        public const string Default = "default";
        public const string Primary = "primary";
        public const string Ghost = "ghost";
        public const string Dashed = "dashed";
        public const string Danger = "danger";
        public const string Link = "link";
    }
    /// <summary>
    /// Button Shape
    /// </summary>
    public static class AntButtonShape
    {
        public const string Circle = "circle";
        public const string CircleOutline = "circle-outline";
        public const string Round = "round";
    }

    /// <summary>
    /// Button size
    /// </summary>
    public static class AntButtonSize
    {
        public const string Large = "large";
        public const string Default = "default";
        public const string Small = "small";
    }
    /// <summary>
    /// Button HTML type
    /// </summary>
    public static class AntButtonHTMLType
    {
        public const string Submit = "submit";
        public const string Button = "button";
        public const string Reset = "reset";
    }

    public class AntButtonComponent : AntBaseComponent
    {

        /// <summary>
        /// Get prefixCls
        /// </summary>
        private string prefixCls = getPrefixCls("btn");

        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
                .Add(prefixCls)
                .Add($"{prefixCls}-{type}", () => !string.IsNullOrEmpty(type))
                .Add($"{prefixCls}-{shape}", () => !string.IsNullOrEmpty(shape))
                 .Add($"{prefixCls}-background-ghost", () => ghost)
                  .Add($"{prefixCls}-block", () => block)
                  .Add($"{prefixCls}-loading", () => loading)
                  .Add($"{prefixCls}-icon-only", () => ChildContent == null && !string.IsNullOrEmpty(icon))
                  .Add($"{prefixCls}-{SizeCls}", () => !string.IsNullOrEmpty(SizeCls));


            return base.OnParametersSetAsync();
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private string _icon;
        [Parameter]
        public string icon
        {
            get
            {
                return loading ? "loading" : _icon;
            }

            set { _icon = value; }
        }

        private string _type;

        [Parameter]
        public string type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }


        private string _shape;

        [Parameter]
        public string shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
            }
        }

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

        private string _htmlType;
        [Parameter]
        public string htmlType
        {
            get { return _htmlType ?? AntButtonHTMLType.Button; }
            set { _htmlType = value; }
        }
        /// <summary>
        /// Render a link if href provided
        /// </summary>
        [Parameter]
        public string href { get; set; }

        [Parameter]
        public bool ghost { get; set; }
        [Parameter]
        public bool block { get; set; }
        [Parameter]
        public bool loading { get; set; }

        [Parameter]
        public bool disabled { get; set; }

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

        [Parameter]
        protected EventCallback<UIMouseEventArgs> OnClick { get; set; }
        protected void OnClickHandler(UIMouseEventArgs ev)
        {
            if (loading || disabled)
            {
                return;
            }
            OnClick.InvokeAsync(ev);
        }

    }
}
