﻿using System;
using System.Diagnostics;
using System.Threading;

namespace Sync_activity
{
    class Program
    {
        private static int sum = 0;
        private static object _Lock = new object();
        static void plus()
        {
            int i;
            lock (_Lock)
            {
                for (i = 1; i < 1000001; i++)

                {
                    sum += i;
                }
            }
                

        }

        static void minus()
        {
            int i;
            lock(_Lock)
            {
                for (i = 0; i < 1000000; i++)
                {
                    sum -= i;
                }
            }
            
        }

        static void Main(string[] args)
        {
            // implement 2 threads
            Thread P = new Thread(new ThreadStart(plus));
            Thread M = new Thread(new ThreadStart(minus));

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start...");
            sw.Start();

            //start thread
            P.Start();
            M.Start();

            //join thread
            P.Join();
            M.Join();

            sw.Stop();
            Console.WriteLine("sum = {0}", sum);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
