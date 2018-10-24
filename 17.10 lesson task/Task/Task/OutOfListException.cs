using System;

namespace Task
{
    class OutOfListException: Exception
    {
        public OutOfListException() : base("The list is full!")
        { }

        public OutOfListException(string message) : base(message)
        { }

        public OutOfListException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
