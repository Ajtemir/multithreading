using System;
using System.Threading;

class Program
{
    private static readonly object lock1 = new object();
    private static readonly object lock2 = new object();

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Thread1);
        Thread thread2 = new Thread(Thread2);

        thread1.Start();
        thread2.Start();

        thread1.Join(2000);
        thread2.Join(2000);

        Console.WriteLine("Работа программы завершена");
    }

    static void Thread1()
    {
        lock (lock1)
        {
            Console.WriteLine("Поток 1 захватил lock1");
            Thread.Sleep(100); // Небольшая пауза для создания условий для deadlock

            lock (lock2)
            {
                Console.WriteLine("Поток 1 захватил lock2");
            }
        }
    }

    static void Thread2()
    {
        lock (lock2)
        {
            Console.WriteLine("Поток 2 захватил lock2");
            Thread.Sleep(100); // Небольшая пауза для создания условий для deadlock

            lock (lock1)
            {
                Console.WriteLine("Поток 2 захватил lock1");
            }
        }
    }
}