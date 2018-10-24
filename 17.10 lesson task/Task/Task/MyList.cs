using System;

namespace Task
{
    class MyList<T>
    {
        Element<T> _head, _tail;

        int _listLength, _listCapasity;

        public MyList(int length)
        {
            if (length < 1)
            {
                throw new IndexOutOfRangeException();
            }

            _listCapasity = length;

            _listLength = 0;
        }

        public void Add(T value)
        {
            if (_listLength == _listCapasity)
            {
                throw new OutOfListException();
            }

            Element<T> node = new Element<T>(value);

            _listLength++;

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.SetNext(node);
            }

            _tail = node;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index >= _listCapasity)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_listLength + 1 > _listCapasity)
            {
                throw new OutOfListException();
            }

            Element<T> node = new Element<T>(value);

            _listLength++;

            int i = 0;

            Element<T> current = _head;

            while (i < index - 1)
            {
                current = current.GetNext();
                i++;
            }

            node.SetNext(current.GetNext());

            current.SetNext(node);
        }

        public T this[int index]
        {
            get
            {
                Element<T> node = _head;

                for (int i = 0; i < index; i++)
                {
                    node = node.GetNext();
                }

                return node.GetValue();
            }
            set
            {
                Element<T> node = _head;

                for (int i = 0; i < index; i++)
                {
                    node = node.GetNext();
                }

                node.SetValue(value);
            }
        }
    }
}
