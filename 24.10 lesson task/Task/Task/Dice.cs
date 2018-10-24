using System;

namespace Task
{
    static class Dice
    {
        public static int ThrowDice()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);

            return rnd.Next(1, 6);
        }
    }
}
