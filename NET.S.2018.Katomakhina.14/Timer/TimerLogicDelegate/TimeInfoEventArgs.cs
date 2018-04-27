using System;

namespace TimerLogicDelegate
{
    public class TimeInfoEventArgs : EventArgs
    {
        private readonly string thisEventProperty, message;
        private readonly TimeSpan time;

        public TimeInfoEventArgs(string thisEventProperty, string message, TimeSpan time)
        {
            this.thisEventProperty = thisEventProperty;
            this.message = message;
            this.time = time;
        }

        public string ThisEventProperty => thisEventProperty;

        public string Message => message;

        public TimeSpan Time => time;
    }
}
