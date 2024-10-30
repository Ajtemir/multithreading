using System;
using System.Threading;

namespace ThreadStatus
{
    // Priority isn’t guaranteed: Thread priority only hints to the OS scheduler; it doesn’t strictly dictate the order.
    class Program
    {
        static void Main(string[] args)
        {
            var redThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("red => " + i);
                }
            });

            var yellowThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"yellow => {i}");
                }
            });
            redThread.Priority = ThreadPriority.Highest;
            yellowThread.Priority = ThreadPriority.Lowest;
            
            redThread.Start();
            yellowThread.Start();

            redThread.Join();
            yellowThread.Join();
            
            Console.WriteLine("Main thread");
        }
    }
}