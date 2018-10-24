using System.Collections;

namespace Task
{
    delegate void FireEventHandler(object sender, FireEventArgs args);

    class City : IEnumerable
    {
        House[] _houses;

        FireService _fireservice;

        public void BuildCity(int numberofhouses)
        {
            _houses = new House[numberofhouses];

            for (int i = 0; i < numberofhouses; i++)
            {
                _houses[i] = new House();
            }

            _fireservice = new FireService(_houses);
        }

        public void FireDrill(int i)
        {
            _houses[i].StartOfFire();
        }

        public IEnumerator GetEnumerator()
        {
            return _houses.GetEnumerator();
        }
    }
}
