namespace Task
{
    class Cylinder : Shape3D
    {
        Circle _base;

        double _height;

        public Cylinder()
        {
            _height = 1;
            _base = new Circle();
        }

        public Cylinder(double radius, double height)
        {
            _height = height;
            _base = new Circle(radius);
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
