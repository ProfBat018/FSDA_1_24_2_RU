#region Part1

var counter = 0;
object lockObject = new();


ThreadPool.QueueUserWorkItem((state) =>
{
    lock (lockObject)
    {
        for (int i = 0; i < 5; i++)
        {
            counter++;
            Console.WriteLine(
                $"Thread: {Thread.CurrentThread}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}, Counter = {counter}");
        }
    }
});


Thread th1 = new(() =>
{
    lock (lockObject)
    {
        for (int i = 0; i < 5; i++)
        {
            counter++;
            Console.WriteLine(
                $"Thread: {Thread.CurrentThread}, IsThreadPool: {Thread.CurrentThread.IsThreadPoolThread}, Counter = {counter}");
        }
    }
});

th1.Start();

#endregion

// Console.WriteLine(ThreadPool.ThreadCount);