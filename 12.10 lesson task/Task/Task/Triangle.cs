using System;

namespace Task
{
    class Triangle : Shape2D
    {
        double _side;

        public Triangle()
        {
            _side = 1;
        }

        public Triangle(double side)
        {
            _side = side;
        }

        public override double Area()
        {
            return (Math.Pow(_side, 2) * Math.Sqrt(3)) / 4;
        }

        public override double Perimeter()
        {
            return 3 * _side;
        }
    }
}
