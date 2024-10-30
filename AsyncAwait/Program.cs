using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Начало работы");

        await DoWorkAsync();

        Console.WriteLine("Работа завершена");
    }

    static async Task DoWorkAsync()
    {
        Console.WriteLine("Работа выполняется асинхронно");
        await Task.Delay(5000); // Имитация длительной работы
        Console.WriteLine("Работа завершена асинхронно");
    }
}