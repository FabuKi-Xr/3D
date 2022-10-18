static void th02(object t)
{
    int adder = 0;
    int j;
    if (plus > 0)
    {
        adder = 1;
        plus--;
    }
    for (int i = 0; i < (int)(qsize / size) + adder; i++)
    {
        lock (_Lock)
        {
            if (Count <= 0)
            {
                Monitor.Wait(_Lock);
                i--;
            }
            else
            {
                j = DeQueue();
                Console.WriteLine("j={0}, thread:{1}", j, t);

                if (Count <= 10)
                {
                    Monitor.Pulse(_Lock);
                }
            }


        }


    }
}