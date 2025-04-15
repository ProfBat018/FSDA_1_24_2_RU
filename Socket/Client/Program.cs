#region Client

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{
    IPAddress serverIP = IPAddress.Parse("127.0.0.1");
    IPEndPoint serverEndPoint = new IPEndPoint(serverIP, 3003);

    clientSocket.Connect(serverEndPoint);
    Console.WriteLine("Connected to server");

    while (true)
    {
        Console.Write("Enter message to send (or 'exit' to quit): ");
        string message = Console.ReadLine();
        byte[] data = Encoding.UTF8.GetBytes(message);

        clientSocket.Send(data);
        Console.WriteLine("Message sent");

        if (message.ToLower() == "exit")
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

#endregion