using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using AntDesign.BaseComponent;
using System.Threading.Tasks;

namespace AntDesign.Button
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
                .Add($"{prefixCls}-{Type}")
                .Add($"{prefixCls}-{Shape}", () => !string.IsNullOrEmpty(Shape))
                 .Add($"{prefixCls}-background-ghost", () => Ghost)
                  .Add($"{prefixCls}-block", () => Block)
                  .Add($"{prefixCls}-loading", () => Loading)
                  .Add($"{prefixCls}-{SizeCls}", () => !string.IsNullOrEmpty(Size));


            return base.OnParametersSetAsync();
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }


        private string _type;

        [Parameter]
        public string Type
        {
            get { return _type ?? AntButtonType.Default; }
            set
            {
                _type = value;
            }
        }


        private string _shape;

        [Parameter]
        public string Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
            }
        }

        private string _size;

        [Parameter]
        public string Size
        {
            get { return _size ?? AntButtonSize.Default; }
            set
            {
                _size = value;
            }
        }

        private string _htmlType;
        [Parameter]
        public string HtmlType
        {
            get { return _htmlType ?? AntButtonHTMLType.Button; }
            set { _htmlType = value; }
        }
        /// <summary>
        /// Render a link if Href provided
        /// </summary>
        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public bool Ghost { get; set; }
        [Parameter]
        public bool Block { get; set; }
        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Size cls
        /// </summary>
        protected string SizeCls
        {
            get
            {
                var sizeCls = "";
                switch (this.Size)
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
            if (this.Loading)
            {
                return;
            }

            if (Href != null)
            {

            }
            else
            {
                OnClick.InvokeAsync(ev);
            }
        }

    }
}
