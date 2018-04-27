using System;
using System.Threading;

namespace TimerLogicDelegate
{
    public class TimerManager
    {
        /*public delegate void NewTimerEventHandler(object sender, TimeInfoEventArgs timeInfo);

        public event NewTimerEventHandler NewTimer;

        protected virtual void OnTimer(object sender, TimeInfoEventArgs timeInfo)
        {
            if (NewTimer != null)
            {
                NewTimer(sender, timeInfo);
            }
            NewTimer?.Invoke(sender, timeInfo);
        }*/

        public event EventHandler<TimeInfoEventArgs> NewTimer = delegate { };

        protected virtual void OnTimer(object sender, TimeInfoEventArgs timeInfo)
        {
            EventHandler<TimeInfoEventArgs> temp = NewTimer;
            temp?.Invoke(this, timeInfo);
        }

        public void SimulateNewMail(string thisEvent, string message, TimeSpan time)
        {
            Thread.Sleep(time);
            OnTimer(this, new TimeInfoEventArgs(thisEvent, message, time));
        }
    }
}
