using System.Net;
using System.Net.Sockets;

TcpListener server = new TcpListener(IPAddress.Any, 3003);

server.Start();
Console.WriteLine($"Server started on {server.Server.RemoteEndPoint}. Waiting for a connection...");

TcpClient client = server.AcceptTcpClient();

Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");

while (true)
{
    NetworkStream stream = client.GetStream();

    byte[] buffer = new byte[1024];

    int bytesRead = stream.Read(buffer, 0, buffer.Length);

    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
    
    Console.WriteLine($"Received message: {message}");
}
