using System;
using System.Threading;

namespace Mutex
{
    /// <summary>
    /// Это гарантирует, что только один поток может обновлять данные в любой момент времени.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            System.Threading.Mutex mutexObj = new();
 
            // запускаем пять потоков
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}";
                myThread.Start(); 
            }
 
            void Print()
            {
                bool mutexExists = false;
                if (mutexExists)
                {
                    mutexObj.WaitOne();     // приостанавливаем поток до получения мьютекса
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }
                    mutexObj.ReleaseMutex();    // освобождаем мьютекс
                }
                else
                {
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }
                }
                
            }
        }
    }
}