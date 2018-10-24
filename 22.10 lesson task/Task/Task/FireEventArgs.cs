using System;

namespace Task
{
    class FireEventArgs : EventArgs
    {
        public bool IsPowerful
        {
            get;
            set;
        }

        public FireEventArgs() : base()
        {
        }
    }
}
