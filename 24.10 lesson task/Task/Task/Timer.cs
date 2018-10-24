using System;
using System.Threading;

namespace Task
{
    delegate void TickEventHandler(object sender, EventArgs args);

    class Timer
    {
        bool _isInfinite;

        int _time;

        public event TickEventHandler Tick;

        public Timer(bool isInfinite, int time)
        {
            _isInfinite = isInfinite;

            _time = time;
        }

        public void Start()
        {
            if (_isInfinite)
            {
                while (true)
                {
                    Thread.Sleep(_time);

                    OnTick();
                }
            }
            else
            {
                Thread.Sleep(_time);

                OnTick();
            }
        }

        protected virtual void OnTick()
        {
            Tick?.Invoke(this, new EventArgs());
        }
    }
}
