using System;

namespace TimerLogic
{
    public class Scoreboard : IObserver
    {
        private IObservable timer;

        public Scoreboard(IObservable observable)
        {
            timer = observable;
            timer.Add(this);
        }

        public void Unregister()
        {
            timer.Remove(this);
        }

        public void Update(int seconds, object information)
        {
            TimeInfo info = (TimeInfo)information;

            Console.WriteLine("Scoreboard time message:");
            Console.WriteLine("What time? {0}!, Who? {1}!, {2} seconds of time passed", info.ThisEventProperty, info.Message, seconds);
        }
    }

    public class Registrar : IObserver
    {
        private IObservable timer;

        public Registrar(IObservable observable)
        {
            timer = observable;
            timer.Add(this);
        }

        public void Unregister()
        {
            timer.Remove(this);
        }

        public void Update(int seconds, object information)
        {
            TimeInfo info = (TimeInfo)information;

            Console.WriteLine("Registrar time message:");
            Console.WriteLine("What time? {0}!, Who? {1}!, {2} seconds of time passed", info.ThisEventProperty, info.Message, seconds);
        }
    }
}
