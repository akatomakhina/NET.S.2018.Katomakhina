using System;

namespace TimerLogicDelegate
{
    public sealed class Scoreboard
    {
        public Scoreboard(TimerManager timer)
        {
            timer.NewTimer += ScoreboardMsg;
        }

        public void Add(TimerManager timer)
        {
            timer.NewTimer += ScoreboardMsg;
        }

        public void Unregister(TimerManager timer)
        {
            timer.NewTimer -= ScoreboardMsg;
        }

        private void ScoreboardMsg(object sender, TimeInfoEventArgs information)
        {
            Console.WriteLine("Scoreboard time message:");
            Console.WriteLine("What time? {0}!, Who? {1}!, {2} seconds of time passed", information.ThisEventProperty, information.Message, information.Time);
        }
    }

    public class Registrar
    {
        public Registrar(TimerManager timer)
        {
            timer.NewTimer += RegistrarMsg;
        }

        public void Add(TimerManager timer)
        {
            timer.NewTimer += RegistrarMsg;
        }

        public void Unregister(TimerManager timer)
        {
            timer.NewTimer -= RegistrarMsg;
        }

        private void RegistrarMsg(object sender, TimeInfoEventArgs information)
        {
            Console.WriteLine("Registrar time message:");
            Console.WriteLine("What time? {0}!, Who? {1}!, {2} seconds of time passed", information.ThisEventProperty, information.Message, information.Time);
        }
    }
}
