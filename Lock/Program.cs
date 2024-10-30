using System;
using System.IO;
using System.Threading;
/// <summary>
/// lock не дает гарантии что будет сихронного выполнения.
/// </summary>
class Program
{
    private static readonly object fileLock = new object();
    private static string filePath = "log.txt";

    static void Main()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        // Simulate multiple threads writing to the same file
        Thread t1 = new Thread(() => WriteToFile("Message from Thread 1"));
        Thread t2 = new Thread(() => WriteToFile("Message from Thread 2"));
        Thread t3 = new Thread(() => WriteToFile("Message from Thread 3"));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("All threads have completed writing to the file.");
    }

    static void WriteToFile(string message)
    {
        var withLock = true;
        if (withLock)
        {
            lock (fileLock)
            {
                using StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        else
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}