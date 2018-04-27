using System;
using TimerLogic;
using TimerLogicDelegate;

namespace TimerRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeManager = new TimerClass();
            var scoreboard = new TimerLogic.Scoreboard(timeManager);
            var registar = new TimerLogic.Registrar(timeManager);
            Console.WriteLine();
            timeManager.SimulateNewMail("It's time to go to school", "Children", 3000);
            Console.WriteLine();

            scoreboard.Unregister();
            timeManager.SimulateNewMail("Time to return home", "Children", 3000);
            Console.ReadKey();


            var timeManagerTwo = new TimerManager();
            var scoreboardTwo = new TimerLogicDelegate.Scoreboard(timeManagerTwo);
            var registarTwo = new TimerLogicDelegate.Registrar(timeManagerTwo);
            Console.WriteLine();
            timeManagerTwo.SimulateNewMail("It's time to go to school", "Children", new TimeSpan(0, 0, 3));
            Console.WriteLine();

            scoreboardTwo.Unregister(timeManagerTwo);
            timeManagerTwo.SimulateNewMail("Time to return home", "Children", new TimeSpan(0,0,3));
            Console.ReadKey();
        }
    }
}
