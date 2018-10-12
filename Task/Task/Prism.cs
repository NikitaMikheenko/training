namespace Task
{
    class Prism : Shape3D
    {
        Triangle _base;

        double _height;

        public Prism()
        {
            _height = 1;
            _base = new Triangle();
        }

        public Prism(double height, double side)
        {
            _height = height;
            _base = new Triangle(side);
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
            return _base.Perimeter() * _height + _base.Area() * 2;
        }
    }
}
