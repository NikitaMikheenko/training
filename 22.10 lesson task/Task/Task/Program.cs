using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();

            city.BuildCity(7);

            int i = 0;

            foreach (House item in city)
            {
                Console.WriteLine($"House {++i}:  {item.IsFire}");
            }

            Random rnd = new Random((int)DateTime.Now.Ticks);

            city.FireDrill(rnd.Next(0, 7)); //Отключено изменение флажка пожара на "Не горит". Поэтому можно увидеть какой дом горел

            i = 0;

            Console.WriteLine();

            foreach (House item in city)
            {
                Console.WriteLine($"House {++i}:  {item.IsFire}");
            }
        }
    }
}