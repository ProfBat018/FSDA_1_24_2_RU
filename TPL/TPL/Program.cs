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

Console.WriteLine("Start of Main Thread");

Task foo()
{
    Console.WriteLine("Start of Task 1");
    
    // Task.Delay(2000).Wait();
    
    Console.WriteLine("End of Task 1");
    
    return Task.CompletedTask;
}

foo();

Console.WriteLine("End of Main Thread");







#endregion