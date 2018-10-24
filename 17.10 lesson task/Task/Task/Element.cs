namespace Task
{
    class Element<T>
    {
        T _value;

        Element<T> _next;

        public Element()
        {

        }

        public Element(T value)
        {
            _value = value;
        }

        public T GetValue()
        {
            return _value;
        }

        public void SetValue(T value)
        {
            _value = value;
        }

        public void SetNext(Element<T> node)
        {
            _next = node;
        }

        public Element<T> GetNext()
        {
            return _next;
        }
    }
}
