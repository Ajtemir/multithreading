using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Create a new thread
        Thread thread = new Thread(PrintNumbers);
        Console.WriteLine($"Thread State after creation: {thread.ThreadState}"); // Unstarted

        // Start the thread
        thread.Start();
        Console.WriteLine($"Thread State after starting: {thread.ThreadState}"); // Running or WaitSleepJoin

        // Wait for the thread to complete
        Console.WriteLine("Main thread waiting for PrintNumbers thread to complete...");
        thread.Join(); // Pauses the main thread until 'thread' completes
        Console.WriteLine($"Thread State after completion: {thread.ThreadState}"); // Stopped

        Console.WriteLine("Main thread resumes after PrintNumbers thread has finished.");
    }

    static void PrintNumbers()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Printing number: {i}");
            Thread.Sleep(300); // Simulate work and change state to WaitSleepJoin
        }
    }
}