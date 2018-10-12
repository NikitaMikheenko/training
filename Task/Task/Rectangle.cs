namespace Task
{
    class Rectangle : Shape2D
    {
        double _lenght, _width;

        public Rectangle()
        {
            _lenght = 1;
            _width = 1;
        }

        public Rectangle(double lenght, double width)
        {
            _lenght = lenght;
            _width = width;
        }

        public override double Area()
        {
            return _lenght * _width;
        }

        public override double Perimeter()
        {
            return 2 * (_lenght + _width);
        }
    }
}
