#region Part1

// Console.WriteLine("Start of Main Thread");
//
// Task.Run(() =>
// {
//     Console.WriteLine("Start of Task 1");
//     Thread.Sleep(2000);
//     Console.WriteLine("End of Task 1");
// });
//
//
// Console.WriteLine("End of Main Thread");

#endregion

#region Part2

// Main Thread 
/*

int number = 5;

Thread th1 = new(() =>
{
    Console.WriteLine("Thread 1 started");

    number = 10;
    Console.WriteLine(number);

    int num2 = 1;
    Console.WriteLine("Thread 1 finished");
});


Thread th2 = new(() =>
{
    Console.WriteLine("Thread 2 started");

    number = 20;
    Console.WriteLine(number);

    Console.WriteLine("Thread 2 finished");
});
*/

#endregion

#region Part3

/*
int number = 0;

Console.WriteLine("Start of main thread");

Task.Run(() =>
{
    Console.WriteLine("This is Task 1, with thread from thradpool");

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(++number);
    }

    Console.WriteLine("End of Task 1");
}).Wait();


Task.Run(() =>
{
    Console.WriteLine("This is Task 2");

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(++number);
    }

    Console.WriteLine("End of Task 2");
}).Wait();

Console.WriteLine("End of main thread");
*/

#endregion

#region Part4

// void findEven(IEnumerable<int> nums)
// {
//     IEnumerable<int> evenNums = nums.Where(x => x % 2 == 0);
//
//     Console.WriteLine("Even nums: ");
//     foreach (var num in evenNums)
//     {
//         Console.Write($"{num} ");
//     }
//     Console.WriteLine();
// }
//
// void findOdd(IEnumerable<int>  nums)
// {
//     IEnumerable<int> oddNums = nums.Where(x => x % 2 != 0);
//
//     Console.WriteLine("Odd nums: ");
//     foreach (var num in oddNums)
//     {
//         Console.Write($"{num} ");
//     }
//     Console.WriteLine();
// }
//
//
// List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//
// Task.Run(() => findEven(nums)).Wait();
// Task.Run(() => findOdd(nums)).Wait();

#endregion

#region Part5

/*

Task findEven(IEnumerable<int> nums)
{
    IEnumerable<int> evenNums = nums.Where(x => x % 2 == 0);

    Console.WriteLine("Even nums: ");
    foreach (var num in evenNums)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();

    return Task.CompletedTask;
}

Task findOdd(IEnumerable<int>  nums)
{
    IEnumerable<int> oddNums = nums.Where(x => x % 2 != 0);

    Console.WriteLine("Odd nums: ");
    foreach (var num in oddNums)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();

    return Task.CompletedTask;
}

List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

findEven(nums).Wait();
findOdd(nums).Wait();
*/

#endregion

#region Part6

/*
Task findEven(IEnumerable<int> nums)
{
    IEnumerable<int> evenNums = nums.Where(x => x % 2 == 0);

    Console.WriteLine("Even nums: ");
    foreach (var num in evenNums)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();

    return Task.CompletedTask;
}

Task findOdd(IEnumerable<int>  nums)
{
    IEnumerable<int> oddNums = nums.Where(x => x % 2 != 0);

    Console.WriteLine("Odd nums: ");
    foreach (var num in oddNums)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();

    return Task.CompletedTask;
}

var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

findEven(nums).GetAwaiter().GetResult();
findOdd(nums).GetAwaiter().GetResult();
*/

#endregion

#region Part7

//
// Task<IEnumerable<int>> findEven(IEnumerable<int> nums)
// {
//     IEnumerable<int> evenNums = nums.Where(x => x % 2 == 0);
//
//     return Task.FromResult(evenNums);
// }
//
// var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//
//
// var res = findEven(nums).GetAwaiter().GetResult();
// findEven(nums).Wait(); // не могу получить возвращаемое значение

#endregion

#region Part8

/*
async Task<IEnumerable<int>> findEven(IEnumerable<int> nums)
{
    IEnumerable<int> evenNums = nums.Where(x => x % 2 == 0);
    return evenNums;
}

async Task<IEnumerable<int>> findOdd(IEnumerable<int> nums)
{
    await Task.Delay(2000);
    IEnumerable<int> oddNums = nums.Where(x => x % 2 != 0);
    return oddNums;
}

var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evenNums = await findEven(nums);
var oddNums = await findOdd(nums);


Console.WriteLine("Even nums: ");
foreach (var num in evenNums)
{
    Console.Write($"{num} ");
}
Console.WriteLine();


Console.WriteLine("Odd nums: ");
foreach (var num in oddNums)
{
    Console.Write( $"{num} ");

}
Console.WriteLine();

// В отличии от кода сверху где каждый блок кода ждал пока выполнится другой в данном случае мы написали асинхронный код.
// Для того чтобы понять во что это все преобразовывается мы можем написать все вручную.

*/

#endregion

#region Part9

/*
Task<IEnumerable<int>> findEven(IEnumerable<int> nums)
{
    return Task.Run(() => nums.Where(x => x % 2 == 0));
}

Task<IEnumerable<int>> findOdd(IEnumerable<int> nums)
{
    return Task.Run(() => nums.Where(x => x % 2 != 0));
}

List<int> nums = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evenNums = findEven(nums).GetAwaiter().GetResult();
var oddNums = findOdd(nums).GetAwaiter().GetResult();

Console.WriteLine("Even nums: ");
foreach (var num in evenNums)
{
    Console.Write($"{num} ");
}
Console.WriteLine();


Console.WriteLine("Odd nums: ");
foreach (var num in oddNums)
{
    Console.Write( $"{num} ");

}
Console.WriteLine();


*/


// Код здесь работает точно так же как и в Part8, но в данном случае мы не используем async/await.
// Наш код выполняется асинхронно без блокирования потоков.

/*
    Фишкой такого подхода является то, что мы используем Task, который использует ThreadPool.
    Наш ThreadPool может быть даже не выделит новый поток, а просто переназначит действие старого.
    Таким образом мы написали многопоточный код без явного использования Thread.

    Это делает код более легковесным и управляемым, так как не нужно заботиться о создании и завершении потоков вручную.
    Task.Run под капотом использует пул потоков, что означает:

    - Нет необходимости вручную управлять жизненным циклом потоков.
    - Потоки переиспользуются, а значит — меньше накладных расходов на создание/уничтожение.
    - Мы можем запускать несколько задач параллельно, не блокируя основной поток.
    - Такой подход хорошо масштабируется при умеренной нагрузке и идеально подходит для CPU-bound задач (как фильтрация).

    Однако важно понимать, что Task.Run не делает код "магически" асинхронным — это просто удобная обёртка для выполнения действий в другом потоке.
    Поэтому если задача не требует тяжелой работы CPU, а, например, работает с I/O (файлы, БД, сеть), лучше использовать настоящие async-методы с await.

    Также стоит быть осторожным при использовании GetAwaiter().GetResult() или .Result — они блокируют поток и **могут привести к deadlock'ам в UI-приложениях** (например, в WPF или WinForms), если не использовать их правильно.

    ✅ В консольных и серверных приложениях (например, ASP.NET Core) такой подход безопасен при контролируемом использовании.

    Вывод: мы избавились от `async/await`, сохранили асинхронность, сделали код многопоточным и понятным, используя `Task` и `ThreadPool` напрямую.
   */

#endregion

#region Part10

/*
Класс Parallel - это класс, который нам нужно для параллельного выполнения задач.
*/

// var nums = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

// Parallel.ForEach(nums, (num) =>
// {
// Console.WriteLine($"This is {num} from Thread {Thread.CurrentThread.ManagedThreadId}");
// });


// Parallel.For(1, 20, (i) =>
// {
// Console.WriteLine($"This is {i} from Thread {Thread.CurrentThread.ManagedThreadId}");
// });

#endregion

#region Part11

/*
var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

var evenNums = nums.AsParallel().Where(num => num % 2 == 0);

foreach (var num in evenNums)
{
    Console.WriteLine(num);
}
*/

#endregion


#region Volatile

/*
     Volatile - это модификатор, который говорит компилятору и среде выполнения, что переменная может быть изменена в другом потоке.
     Это значит, что компилятор не должен оптимизировать доступ к этой переменной, и всегда должен считывать её значение из памяти, а не из кэша.
     Это важно, когда у нас есть несколько потоков, которые могут изменять одну и ту же переменную.
*/

class Test
{
    public volatile int number = 0;
}




#endregion