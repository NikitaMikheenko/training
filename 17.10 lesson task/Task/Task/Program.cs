using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(3);

            list.Add(1);
            list.Add(2);

            list.Insert(1, 3);

            list[0] = 6;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(list[i]);
            }

            try
            {
                list.Add(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        } 
    }
}