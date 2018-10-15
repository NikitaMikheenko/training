using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = "275";
            BigNumber b = 25;
            BigNumber c = new BigNumber(2);

            Console.WriteLine(a > b);

            Console.WriteLine(c == a);

            BigNumber d = (a + b) * c;

            Console.WriteLine(d);
        } 
    }
}