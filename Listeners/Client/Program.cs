using System.Net;
using System.Net.Sockets;
using System.Text;

Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

Console.Write("Enter your username: ");
byte[] usernameData = Encoding.UTF8.GetBytes(Console.ReadLine());

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

        byte[] dataWithUsername = new byte[usernameData.Length + data.Length];
        
        Buffer.BlockCopy(usernameData, 0, dataWithUsername, 0, usernameData.Length);
        Buffer.BlockCopy(data, 0, dataWithUsername, usernameData.Length, data.Length);
        
        clientSocket.Send(dataWithUsername);
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