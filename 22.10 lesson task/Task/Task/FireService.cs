namespace Task
{
    class FireService
    {
        FireTruck _firetruck1 = new FireTruck();

        FireTruck _firetruck2 = new FireTruck();

        public FireService(House[] houses)
        {
            for (int i = 0; i < houses.Length; i++)
            {
                houses[i].Fire += new FireEventHandler(FireFighting); 
            }
        }

        void FireFighting(object sender, FireEventArgs args)
        {
            if (((House)sender).IsFire)
            {
                if (args.IsPowerful)
                {
                    if (!_firetruck1.IsBusy && !_firetruck2.IsBusy)
                    {
                        _firetruck1.IsBusy = true;

                        _firetruck2.IsBusy = true;

                        //((House)sender).IsFire = false;

                        _firetruck1.IsBusy = false;

                        _firetruck2.IsBusy = false;
                    }
                    else
                    {
                        FireFighting(sender, args);
                    }
                }
                else
                {
                    if (!_firetruck1.IsBusy)
                    {
                        _firetruck1.IsBusy = true;

                        //((House)sender).IsFire = false;

                        _firetruck2.IsBusy = false;
                    }
                    else if(!_firetruck2.IsBusy)
                    {
                        _firetruck2.IsBusy = true;

                        //((House)sender).IsFire = false;

                        _firetruck2.IsBusy = false;
                    }
                    else
                    {
                        FireFighting(sender, args);
                    }
                }
            }
        }
    }
}
