#region Mutex

/*
class Program
{
    private static Mutex mutex = new();
    
    public static void CountToFive()
    {
        mutex.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
        }
        mutex.ReleaseMutex();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main started...");
        for (int i = 0; i < 5; i++)
        {
            Thread th = new(CountToFive);
            Console.WriteLine($"Created thread");
            th.Start();
        }
    }
}

*/

#endregion

#region Semaphore

/*
using System;
using System.Threading;

class Program
{
    private static readonly Semaphore semaphore = new(2, 2); // Один семафор для всех потоков

    public static void Sample()
    {
        semaphore.WaitOne();

        try
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hello from: {Thread.CurrentThread.ManagedThreadId}\t{count}");
                count++;
                Thread.Sleep(100); // Имитируем работу
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    public static void Main(string[] args)
    {
        Thread[] threads = new Thread[6];

        for (int i = 0; i < 6; i++)
        {
            threads[i] = new Thread(Sample);
            threads[i].Start();
        }
    }
}
*/

#endregion

#region CountDownEvent
/*
class Program
{
    private static CountdownEvent countdownEvent = new(5);
    private static Mutex mutex = new();

    public static void Sample()
    {
        mutex.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Hello from: {Thread.CurrentThread.ManagedThreadId}");
        }

        countdownEvent.Signal();
        mutex.ReleaseMutex();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main started");

        for (int i = 0; i < 5; i++)
        {
            Thread th1 = new(Sample);
            th1.Start();
        }

        countdownEvent.Wait();

        Console.WriteLine("Main finished");
    }
}
*/
#endregion

#region ManualResetEvent

/*
using System;
using System.Threading;

class Program
{
    private static readonly ManualResetEvent manualEvent = new(false);
    private static int completedThreads = 0;
    private static readonly object lockObject = new();

    static void Worker(int id)
    {
        Console.WriteLine($"Поток {id} начал выполнение.");
        Thread.Sleep(100); // Имитация работы

        Console.WriteLine($"Поток {id} завершил выполнение.");

        lock (lockObject)
        {
            completedThreads++;
            if (completedThreads == 3) // Когда все потоки завершены
            {
                manualEvent.Set(); // Уведомляем Main, что все потоки завершены
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Запуск потоков...");

        for (int i = 1; i <= 3; i++)
        {
            new Thread(() => Worker(i)).Start();
        }

        Console.WriteLine("Ожидание завершения всех потоков...");
        manualEvent.WaitOne(); // Main ждёт, пока все 3 потока завершат работу

        Console.WriteLine("Все потоки завершены, продолжаем выполнение Main.");
    }
}
*/
#endregion

#region AutoResetEvent

class Program
{
    private static AutoResetEvent autoResetEvent = new(false);
    
    public static void Sample()
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} started");
        autoResetEvent.WaitOne();
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} finished");
    }
    
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Start of main thread");
        for (int i = 0; i < 3; i++)
        {
            Thread th = new(Sample);
            th.Start();
            
            Thread.Sleep(1000);
            
            autoResetEvent.Set();
        }
        
        
        Console.WriteLine("End of main thread");
        
    }
}

#endregion

#region ThreadPool

/*
class Program
{
    public static void Sample()
    {
        using Mutex mutex = new();

        mutex.WaitOne();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{i} from thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.IsThreadPoolThread}");
        }
        mutex.ReleaseMutex();

    }

    public static void Main(string[] args)
    {
        CountdownEvent countdownEvent = new(5);

        Console.WriteLine("Main started");

        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Sample();
                countdownEvent.Signal();
            });
        }
        countdownEvent.Wait();

        Console.WriteLine("Main finished");
    }
}
*/

#endregion