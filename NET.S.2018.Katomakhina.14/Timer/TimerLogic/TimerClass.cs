using System;
using System.Collections.Generic;
using System.Threading;

namespace TimerLogic
{
    public class TimerClass : IObservable
    {
        private List<IObserver> observers;
        private TimeSpan timer;
        private TimeInfo timeInfo;

        public TimerClass()
        {
            observers = new List<IObserver>();
            timeInfo = new TimeInfo();
        }

        public void Add(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"{nameof(observer)} must be not null");
            }
            observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"{nameof(observer)} must be not null");
            }
            observers.Remove(observer);
        }

        public void Notify(int seconds)
        {
            Thread.Sleep(seconds);

            foreach (IObserver thisObserver in observers)
            {
                thisObserver.Update(seconds, timeInfo);
            }
        }

        public void SimulateNewMail(string eventProperty, string message, int seconds)
        {
            timeInfo.ThisEventProperty = eventProperty;
            timeInfo.Message = message;
            Notify(seconds);
        }
    }
}
