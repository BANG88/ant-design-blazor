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
    public class AntMessageComponent : AntBaseComponent
    {
        protected string prefixCls = getPrefixCls("message");
        protected override Task OnParametersSetAsync()
        {
            ClassNames.Clear()
               .Add(prefixCls);

            return base.OnParametersSetAsync();
        }
    }
}
