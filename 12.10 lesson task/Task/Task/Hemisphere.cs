namespace Task
{
    class Hemisphere : Shape3D
    {
        Circle _base;

        double _radius;

        public Hemisphere()
        {
            _radius = 1;
            _base = new Circle();
        }

        public Hemisphere(double radius)
        {
            _radius = radius;
            _base = new Circle(radius);
        }

        public override double BaseArea()
        {
            return _base.Area();
        }

        public override double Volume()
        {
            return ((4 / 3) * _base.Area() * _radius) / 2;
        }

        public override double SurfaceArea()
        {
            return 2 * _base.Area();
        }
    }
}
