using System.Threading;

namespace OS_Sync_01
{
    class Program
    {
        private static string x = "";
        private static int exitflag = 0;
        private static object _Lock = new object();
        static void ThReadX()
        {
            
                while (exitflag == 0)
                {
                    
                        lock (_Lock)
                        {

                            Monitor.Wait(_Lock);
                            Monitor.Pulse(_Lock);
                            if (exitflag == 0)
                            {
                                Console.WriteLine("X = {0}", x);

                            }
                        }
                    
                }
                Console.Write("---Thread 1 exit---");


        }

        static void ThWriteX()
        {
            string xx;

            while (exitflag == 0 )
            {

                Console.Write("Input: ");
                xx = Console.ReadLine();
                lock (_Lock)
                {
                    if (xx == "exit")
                    {
                        exitflag = 1;
                        Monitor.Pulse(_Lock);
                        Monitor.Wait(_Lock);
                    }
                    else
                    {
                        x = xx;
                        Monitor.Pulse(_Lock);
                        Monitor.Wait(_Lock);
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            Thread A = new Thread(ThReadX);
            Thread B = new Thread(ThWriteX);

            A.Start();
            B.Start();  

        }
    }
}