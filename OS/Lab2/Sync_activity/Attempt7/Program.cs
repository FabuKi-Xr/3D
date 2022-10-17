/*โค้ดโง่ๆ ของน้องรอมเอง*/
using System;
using System.Threading;

namespace OS_Problem_02
{
    class Thread_safe_buffer
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0; // ใช้เปลี่ยนตำแหน่งใน Array TSBuffer **ตอน dequeue
        static int Back = 0;  // ใช้เพื่อเปลี่ยนตำแหน่งใน array TSBuffer **ตอนใส่ลง array
        static int Count = 0; // ใช้เพื่อนับจำนวนทั้งหมดที่เข้ามาใน buffer 
        static int updateDQ = 1; // ใช้เพื่อเช็คว่า มีการ dequeue แล้ว
        static int updateNQ = 0; // ใช้เพื่อเช็คว่า มีการ enqueue แล้ว
        static int plus = 0;
        private static object _Lock = new object();
        static int size = 3;
        static int qsize = 101;
        static void EnQueue(int eq)
        {

            TSBuffer[Back] = eq;
            Back++;
            Back %= 10;
            Count += 1;

        }

        static int DeQueue()
        {
            int x = 0;

            x = TSBuffer[Front];
            Count -= 1;

            Front++;
            Front %= 10;

            return x;
        }

        static void th01()
        {
            Monitor.Enter(_Lock);
            try
            {
                for (int i = 1; i < 51; i++)
                {
                    //Console.WriteLine("th01 -> i = {0}", i);
                    if (updateNQ == 0 && updateDQ == 1)
                    {

                        EnQueue(i);
                        updateNQ = 1;
                        updateDQ = 0;
                    }
                    else
                    {
                        i--;
                    }
                    
                    Monitor.Pulse(_Lock);
                    Monitor.Wait(_Lock);
                }
            }
            finally
            {
                Monitor.Pulse(_Lock);
                Monitor.Exit(_Lock);

            }

        }

        static void th011()
        {
            
            Monitor.Enter(_Lock);
            try
            {
                
                int i;
                for (i = 100; i < 151; i++)
                {

                    if (updateNQ == 0 && updateDQ == 1)
                    {

                        EnQueue(i);
                        updateNQ = 1;
                        updateDQ = 0;
                    }
                    else 
                    {

                        i--;
                    }

                    Monitor.Pulse(_Lock);
                    Monitor.Wait(_Lock);
                }
                

            }
            finally
            {

                Monitor.Pulse(_Lock);

                Monitor.Exit(_Lock);
            }

        }

        static void th02(object t)
        {

            Monitor.Enter(_Lock);
            try
            {
                int adder = 0;
                int j;
                if (plus > 0)
                {
                    
                    adder = 1;
                    plus--;
                }
                for (int i = 0 ; i < (int)(101 / size) + adder; i++)
                {

                    if (updateNQ == 1 &&updateDQ == 0)
                    {
                        updateDQ = 1;                
                        j = DeQueue();

                        Console.WriteLine("j={0}, thread:{1}", j, t);
                        if (Count >= 0)
                        {
                            
                            updateNQ = 0;
                            Monitor.Pulse(_Lock);
                            Monitor.Wait(_Lock);
                            
                        }
                        else
                        {
                            Monitor.Pulse(_Lock);

                            break;
                        }

                    }
                    else
                    {
                        i--;
                        Monitor.Pulse(_Lock);
                        Monitor.Wait(_Lock);
                    }


                }
            }
            finally
            {
                Monitor.Pulse(_Lock);
                Monitor.Exit(_Lock);
            }


        }
        static void Main(string[] args)
        {
            plus = (qsize % size);
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            t1.Start();
            t11.Start();
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);
        }
    }
}
