using System;

namespace Task
{
    abstract class Shape2D : IComparable
    {
        public abstract double Area();
        public abstract double Perimeter();
        public int CompareTo(object obj)
        {
            return Area().CompareTo(((Shape2D)obj).Area());
        }
    }
}
