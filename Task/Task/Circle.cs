using System;

namespace Task
{
    class Circle : Shape2D
    {
        double _radius;

        public Circle()
        {
            _radius = 1;
        }

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}
