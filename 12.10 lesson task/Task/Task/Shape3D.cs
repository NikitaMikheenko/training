using System;

namespace Task
{
    abstract class Shape3D : IComparable
    {
        public abstract double BaseArea();
        public abstract double Volume();
        public abstract double SurfaceArea();
        public int CompareTo(object obj)
        {
            return Volume().CompareTo(((Shape3D)obj).Volume());
        }
    }
}
