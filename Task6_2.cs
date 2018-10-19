namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            float cost = 0;

            Iflower[] bouquet = new Iflower[] { new Rose(), new Tulip(), new Rose(), new Chrysanthemum(), new Chrysanthemum(), new Chrysanthemum()};

            foreach (var item in bouquet)
            {
                cost += item.Cost();
            }

            System.Console.WriteLine(cost);
        } 
    }

    interface Iflower
    {
        float Cost();
    }

    class Flower : Iflower
    {
        float _cost;

        public Flower(float cost)
        {
            _cost = cost;
        }

        public float Cost()
        {
            return _cost;
        }
    }

    class Rose : Flower
    {
        public Rose() : base(3f)
        { }
    }

    class Carnation : Flower
    {
        public Carnation() : base(1.5f)
        { }
    }

    class Tulip : Flower
    {
        public Tulip() : base(1f)
        { }
    }

    class Chrysanthemum : Flower
    {
        public Chrysanthemum() : base(2.5f)
        { }
    }
}