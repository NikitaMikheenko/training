namespace Task
{
    class Cube : Shape3D
    {
        Rectangle _base;

        double _height;

        public Cube()
        {
            _height = 1;
            _base = new Rectangle();
        }

        public Cube(double side)
        {
            _height = side;
            _base = new Rectangle(side, side);
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
            return _base.Area() * 6;
        }
    }
}
