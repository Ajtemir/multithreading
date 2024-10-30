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
        Console.WriteLine($"Thread State after starting: {thread.ThreadState}"); // Running or WaitSleepJoin (depends on timing)

        // Monitor the thread status
        while (thread.IsAlive)
        {
            Console.WriteLine($"Thread State while running: {thread.ThreadState}");
            Thread.Sleep(100); // Give some time to observe the state
        }

        // After thread completion
        Console.WriteLine($"Thread State after completion: {thread.ThreadState}"); // Stopped
    }

    static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Printing number: {i}");
            Thread.Sleep(200); // Simulate work and change state to WaitSleepJoin
        }
    }
}