using System;
using System.Collections;
using System.Collections.Generic;

namespace Task
{
    class NumberEnumerator : IEnumerator
    {
        List<byte> _number;

        int position;

        public NumberEnumerator(List<byte> number)
        {
            this._number = number;
            position = _number.Count;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= _number.Count)
                    throw new InvalidOperationException();
                return _number[position];
            }
        }

        public bool MoveNext()
        {
            if (position > 0)
            {
                position--;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = _number.Count;
        }
    }
}
