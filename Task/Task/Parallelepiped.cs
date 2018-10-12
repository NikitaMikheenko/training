namespace Task
{
    class Parallelepiped : Shape3D
    {
        Rectangle _base;

        double _height;

        public Parallelepiped()
        {
            _height = 1;
            _base = new Rectangle();
        }

        public Parallelepiped(double lenght, double width, double height)
        {
            _height = height;
            _base = new Rectangle(lenght, width);
        }

        public override double BaseArea()
        {
            return _base.Area();
        }

        public override double Volume()
        {
            return _base.Area() * _height;
        }

        public override double SurfaceArea()
        {
            return _base.Perimeter() * _height + 2 * _base.Area();
        }
    }
}
