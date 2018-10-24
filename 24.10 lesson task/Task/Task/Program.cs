using System;
using System.Threading;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(true, 1000);

            timer.Tick += new TickEventHandler(TimerTick);

            Thread first = new Thread(timer.Start);

            first.Start();
        }

        static void TimerTick(object sender, EventArgs args)
        {
            Console.WriteLine($"Dice: {Dice.ThrowDice()}");
        }
    }
}