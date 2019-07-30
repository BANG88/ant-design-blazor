using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    public class MessageType
    {
        public const string info = "info";
        public const string success = "success";
        public const string error = "error";
        public const string warning = "warning";
        public const string loading = "loading";
    }
    /// <summary>
    /// Base Component for AntMessage
    /// </summary>
    public class AntMessageComponent : AntBaseComponent, IDisposable
    {
        protected bool IsVisible { get; set; }
        protected string Message { get; set; }
        protected string type { get; set; }
        [Inject] AntMessageService AntMessageService { get; set; }
        protected string prefixCls = getPrefixCls("message");

        /// <summary>
        /// duration in seconds
        /// </summary>
        [Parameter]
        public double duration { get; set; } = 2;

        protected override void OnInit()
        {
            AntMessageService.OnShow += ShowMessage;
            AntMessageService.OnHide += HideMessage;
        }
        protected override void OnParametersSet()
        {
            AntMessageService.interval = duration;
            base.OnParametersSet();
        }
        private void ShowMessage(string message, string messageType)
        {
            // rebuild
            ClassNames.Clear()
              .Add(prefixCls);
            Message = message;

            type = messageType ?? MessageType.info;

            IsVisible = true;
            StateHasChanged();
        }
        private void HideMessage()
        {
            IsVisible = false;
            StateHasChanged();
        }

        public void Dispose()
        {
            AntMessageService.OnShow -= ShowMessage;
        }
        protected string IconTheme
        {
            get => IconType.Equals("loading") ? AntIconTheme.Outline : AntIconTheme.Fill;
        }
        public string IconType
        {
            get
            {
                string t;

                switch (type)
                {
                    case MessageType.success:
                        t = "check-circle";
                        break;
                    case MessageType.error:
                        t = "close-circle";
                        break;
                    case MessageType.warning:
                        t = "exclamation-circle";
                        break;
                    case MessageType.loading:
                        t = "loading";
                        break;
                    default:
                        t = "info-circle";
                        break;
                }

                return t;
            }
        }
    }
}
