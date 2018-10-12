using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2D:");

            Shape2D[] array2D = new Shape2D[] { new Rectangle(5, 4), new Rectangle(7, 7), new Triangle(4), new Circle(2) };
            Array.Sort(array2D);

            foreach (var item in array2D)
            {
                Console.WriteLine(item.Area());
            }

            Console.WriteLine("3D:");

            Shape3D[] array3D = new Shape3D[] { new Cube(4), new Parallelepiped(7, 8, 3), new Hemisphere(7), new Prism(5, 3), new Cylinder(5, 8) };
            Array.Sort(array3D);

            foreach (var item in array3D)
            {
                Console.WriteLine(item.BaseArea());
            }
        } 
    }
}