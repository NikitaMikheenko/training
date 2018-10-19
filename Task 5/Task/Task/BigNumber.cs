using System;
using System.Collections;
using System.Collections.Generic;

namespace Task
{
    class BigNumber : IComparable, IEnumerable
    {
        List<byte> _number;

        bool _isPositive;

        public BigNumber()
        {
            _number = new List<byte>();
            _isPositive = true;
        }

        public BigNumber(string number)
        {
            Initialization<string>(number);
        }

        public BigNumber(byte number)
        {
            Initialization<byte>(number);
        }

        public BigNumber(sbyte number)
        {
            Initialization<sbyte>(number);
        }

        public BigNumber(short number)
        {
            Initialization<short>(number);
        }

        public BigNumber(ushort number)
        {
            Initialization<ushort>(number);
        }

        public BigNumber(int number)
        {
            Initialization<int>(number);
        }

        public BigNumber(uint number)
        {
            Initialization<uint>(number);
        }

        public BigNumber(long number)
        {
            Initialization<long>(number);
        }

        public BigNumber(ulong number)
        {
            Initialization<ulong>(number);
        }

        void Initialization<T>(T param)
        {
            _number = new List<byte>();
            _isPositive = true;

            string number = Convert.ToString(param);

            int j, i;

            i = number.Length - 1;
            j = 0;

            if (number[0] == '-')
            {
                _isPositive = false;
                j = 1;
            }

            while (i >= j)
            {
                _number.Add((byte)Char.GetNumericValue(number[i]));
                i--;
            }
        }

        static List<byte> Plus(List<byte> first, List<byte> second)
        {
            byte plus = 0;
            byte sum;

            List<byte> result = new List<byte>();
            List<byte> summand = new List<byte>();

            for (int i = 0; i < first.Count; i++)
            {
                if (i >= second.Count)
                    summand.Add(0);
                else
                    summand.Add(second[i]);

                sum = (byte)((first[i] + summand[i] + plus) % 10);
                plus = (byte)((first[i] + summand[i] + plus) / 10);

                result.Add(sum);
            }

            return result;
        }

        static List<byte> Minus(List<byte> first, List<byte> second)
        {
            byte minus = 0;

            List<byte> result = new List<byte>();
            List<byte> subtrahend = new List<byte>();

            for (int i = 0; i < first.Count; i++)
            {
                if (i >= second.Count)
                    subtrahend.Add(0);
                else
                    subtrahend.Add(second[i]);

                if ((first[i] - subtrahend[i] - minus) < 0)
                {
                    result.Add((byte)(first[i] - subtrahend[i] - minus + 10));
                    minus = 1;
                }
                else
                {
                    result.Add((byte)(first[i] - subtrahend[i] - minus));
                    minus = 0;
                }
            }

            return result;
        }

        static List<byte> Multiply(List<byte> first, byte second)
        {
            byte plus = 0;
            byte multiplier;

            List<byte> result = new List<byte>();

            for (int i = 0; i < first.Count; i++)
            {
                multiplier = (byte)((first[i] * second + plus) % 10);
                plus = (byte)((first[i] * second + plus) / 10);
                result.Add(multiplier);
            }

            if (plus > 0)
                result.Add(plus);

            return result;
        }

        public static BigNumber operator +(BigNumber first, BigNumber second)
        {
            BigNumber obj = new BigNumber();

            if (first.CompareTo(second) < 0)
            {
                obj = first;
                first = second;
                second = obj;
            }

            if (first._isPositive == false || second._isPositive == false)
                obj._number = Minus(first._number, second._number);
            else
                obj._number = Plus(first._number, second._number);

            return obj;
        }

        public static BigNumber operator -(BigNumber first, BigNumber second)
        {
            BigNumber obj = new BigNumber();

            if (first.CompareTo(second) < 0)
            {
                obj = first;
                first = second;
                second = obj;

                obj._isPositive = false;
            }

            if (first._isPositive ^ second._isPositive)
                obj._number = Plus(first._number, second._number);
            else
                obj._number = Minus(first._number, second._number);

            if (!first._isPositive)
                obj._isPositive = !obj._isPositive;

            return obj;
        }

        public static BigNumber operator *(BigNumber first, BigNumber second)
        {
            BigNumber obj = new BigNumber();

            List<byte> multiply = new List<byte>();

            if (first.CompareTo(second) < 0)
            {
                obj = first;
                first = second;
                second = obj;
            }

            if (second._number.Count == 1)
            {
                obj._number = Multiply(first._number, second._number[0]);
            }
            else
            {
                for (int i = 0; i < first._number.Count; i++)
                {
                    multiply = Multiply(second._number, first._number[i]);
                    for (int j = 0; j < i; j++)
                        multiply = Multiply(multiply, 10);
                    obj._number = Plus(multiply, obj._number);
                }
            }

            if (!first._isPositive || !second._isPositive)
                obj._isPositive = false;

            return obj;
        }

        public static bool operator >(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) == 1)
                return true;
            else
                return false;
        }

        public static bool operator >=(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) >= 0)
                return true;
            else
                return false;
        }

        public static bool operator <(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) == -1)
                return true;
            else
                return false;
        }

        public static bool operator <=(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) <= 0)
                return true;
            else
                return false;
        }

        public static bool operator ==(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) == 0)
                return true;
            else
                return false;
        }

        public static bool operator !=(BigNumber first, BigNumber second)
        {
            if (first.CompareTo(second) != 0)
                return true;
            else
                return false;
        }

        public static implicit operator BigNumber(string param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(byte param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(sbyte param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(short param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(ushort param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(int param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(uint param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(long param)
        {
            return new BigNumber(param);
        }

        public static implicit operator BigNumber(ulong param)
        {
            return new BigNumber(param);
        }

        public static implicit operator string(BigNumber param)
        {
            string str = "";
            if (!param._isPositive)
                str += "-";
            foreach (var item in param)
                str += Convert.ToString(item);
            return str;
        }

        public int CompareTo(object obj)
        {
            return this._number.Count.CompareTo(((BigNumber)obj)._number.Count);
        }

        public byte this[int index]
        {
            get
            {
                return _number[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new NumberEnumerator(_number);
        }

        public override bool Equals(object obj)
        {
            var number = obj as BigNumber;
            return number != null &&
                   EqualityComparer<List<byte>>.Default.Equals(_number, number._number) &&
                   _isPositive == number._isPositive;
        }

        public override int GetHashCode()
        {
            var hashCode = 1972012876;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<byte>>.Default.GetHashCode(_number);
            hashCode = hashCode * -1521134295 + _isPositive.GetHashCode();
            return hashCode;
        }
    }
}
