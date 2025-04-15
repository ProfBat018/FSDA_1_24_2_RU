#region Part1

using System.Net;
using System.Net.Sockets;
using System.Text;

Socket serverSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress address = IPAddress.Parse("127.0.0.1"); // всегда localhost 
IPEndPoint endPoint = new(address, 3003);

var buffer = new byte[1024]; // делаю буферный массив для получения данных 

serverSocket.Bind(endPoint);
serverSocket.Listen();

Console.WriteLine($"Listening on {endPoint.Address}:{endPoint.Port}");

while (true)
{
    Socket clientSocket = serverSocket.Accept(); // принимаю клиента 
    Console.WriteLine($"Client connected: {clientSocket.RemoteEndPoint}");

    int bytesRead = clientSocket.Receive(buffer); // получаю данные от клиента 
    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    Console.WriteLine($"Received message: {message}");
}

#endregion
