using System;
using System.Threading;
// ปัญหา การใช้ fix lock ลองเอา lock มาใช้ โดยคลุมทั้ง for
namespace OS_Problem_02
{
    class Thread_safe_buffer
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0; // ใช้เปลี่ยนตำแหน่งใน Array TSBuffer **ตอน dequeue
        static int Back = 0;  // ใช้เพื่อเปลี่ยนตำแหน่งใน array TSBuffer **ตอนใส่ลง array
        static int Count = 0; // ใช้เพื่อนับจำนวนทั้งหมดที่เข้ามาใน buffer 
        private static object _Lock = new object();
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
            int i;
            lock (_Lock)
            {
                //Console.WriteLine("InLock");
                for (i = 1; i < 51; i++)
                {
                    EnQueue(i);
                    Thread.Sleep(5);
                }
            }
            
        }

        static void th011()
        {
            int i;

            for (i = 100; i < 151; i++)
            {
                EnQueue(i);
                Thread.Sleep(5);
            }

            
        }


        static void th02(object t)
        {
            int i;
            int j;
            lock (_Lock)
            {
                for (i = 0; i < 60; i++)
                {
                    j = DeQueue();
                    Console.WriteLine("j={0}, thread:{1}", j, t);
                    Thread.Sleep(100);
                }
            }
            
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(th01);
            //Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            //Thread t21 = new Thread(th02);
            //Thread t22 = new Thread(th02);

            t1.Start();
            //t11.Start();
            t2.Start(1);
            //t21.Start(2);
            //t22.Start(3);
        }
    }
}
