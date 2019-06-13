using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.BaseComponent
{
    public class AntBaseComponent : ComponentBase, IDisposable
    {
        protected string getPrefixCls(string suffixCls)
        {
            string prefixCls = "ant";

            return string.IsNullOrEmpty(suffixCls) ? prefixCls : $"{prefixCls}-{suffixCls}";
        }
        private ElementRef _ref;

        public ElementRef Ref
        {
            get { return _ref; }
            set { _ref = value; }
        }

        public ClassNames ClassNames { get; } = new ClassNames();
        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassNames.MakeDirty();
            }
        }


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                this.StateHasChanged();
            }
        }

        private string _class;
        private string _style;

        protected AntBaseComponent()
        {
            ClassNames.Get(() => this.Class);
        }

        private Queue<Func<Task>> afterRenderCallQuene = new Queue<Func<Task>>();

        private bool isRendered = false;

        protected void CallAfterRender(Func<Task> action)
        {
            afterRenderCallQuene.Enqueue(action);
        }
        protected async virtual Task OnFirstAfterRenderAsync()
        {
        }
        protected async override Task OnAfterRenderAsync()
        {
            if (!isRendered)
            {
                await OnFirstAfterRenderAsync();
                isRendered = true;
            }

            if (afterRenderCallQuene.Count > 0)
            {
                var actions = afterRenderCallQuene.ToArray();
                afterRenderCallQuene.Clear();

                foreach (var action in actions)
                {
                    if (Disposed)
                    {
                        return;
                    }

                    await action();
                }
            }
        }

        public virtual void Dispose()
        {
            Disposed = true;
        }

        protected bool Disposed { get; private set; }
    }
}
