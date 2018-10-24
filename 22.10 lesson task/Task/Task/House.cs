using System;

namespace Task
{
    class House
    {
        public event FireEventHandler Fire;

        public bool IsFire
        {
            get;
            set;
        }

        protected virtual void OnFire(FireEventArgs args)
        {
            Fire?.Invoke(this, args);
        }

        public void StartOfFire()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);

            IsFire = true;

            if (rnd.Next(0, 100) > 50)
            {
                OnFire(new FireEventArgs() { IsPowerful = true });
            }
            else
            {
                OnFire(new FireEventArgs() { IsPowerful = false });
            }
        }
    }
}
