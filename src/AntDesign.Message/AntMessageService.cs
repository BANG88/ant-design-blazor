using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace AntDesign
{
    /// <summary>
    /// TODO: Support multiple message at once
    /// </summary>
    public class AntMessageService : IDisposable
    {
        public event Action<string, string> OnShow;
        public event Action OnHide;
        public double interval;
        private Timer timer;
        public void Dispose()
        {
            timer?.Dispose();
        }


        public void Show(string message, string messageType)
        {
            OnShow?.Invoke(message, messageType);
            startTimer();
        }
        private void startTimer()
        {
            if (timer == null)
            {
                timer = new Timer(interval * 1000);
                timer.Elapsed += hide;
                timer.AutoReset = false;
            }
            if (timer.Enabled)
            {
                timer.Stop();
            }
            timer.Start();
        }
        private void hide(object s, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }
    }
}
