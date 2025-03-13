using System.Diagnostics;

Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} started");

string childApp =
    "/Users/wayne/Documents/Work/FSDA_1_24_2_RU/Processes/ChildApp/bin/Debug/net9.0/ChildApp"; // Путь к исполняемому файлу

ProcessStartInfo psi = new ProcessStartInfo
{
    FileName = childApp,
    Arguments = "Elvin Ilkin Ramazan",
    RedirectStandardOutput = true
};

using Process process = new Process { StartInfo = psi };

process.EnableRaisingEvents = true;
process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
process.Exited += (sender, e) => Console.WriteLine($"Child process with id: {process.Id} finished");

process.Start();

Console.WriteLine($"Child process with id: {process.Id} started");

process.BeginOutputReadLine();

process.WaitForExit();


Console.WriteLine($"Process with id: {Process.GetCurrentProcess().Id} finished");