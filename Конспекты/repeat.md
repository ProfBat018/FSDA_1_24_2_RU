# Тема урока:
- Ключевое слово `volatile`

## Ключевое слово `volatile`

`volatile` гарантирует, что чтение и запись переменной будет происходить напрямую из основной памяти, а не из кеша потока. Это важно для переменных, которые читаются и записываются несколькими потоками без блокировок.

```csharp
using System;
using System.Threading;

class Program
{
    static volatile bool isRunning = true;

    static void Main()
    {
        Thread t = new Thread(Worker);
        t.Start();

        Thread.Sleep(1000);
        isRunning = false;
        t.Join();
    }

    static void Worker()
    {
        while (isRunning)
        {
            // выполняем работу
        }

        Console.WriteLine("Worker stopped");
    }
}
```
