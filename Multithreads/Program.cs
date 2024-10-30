using System;
using System.Threading;

namespace Multithreads
{
    /// <summary>
    /// Здесь нам следует как идет борьба за консоль
    /// </summary>
    class Program
    { 
        static void Main(string[] args)
        {
            var redThread = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(1);
                    Console.WriteLine("red => " + i);
                }
            });

            var yellowThread = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(1);
                    Console.WriteLine($"yellow => {i}");
                }
            });
            
            redThread.Start();
            yellowThread.Start();
            Console.WriteLine("Main thread");
        }
    }
}