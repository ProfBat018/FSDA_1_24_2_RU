using System.Net.Sockets;

TcpClient client = new("172.20.28.8", 3003);

Console.WriteLine($"Connected to server: {client.Client.RemoteEndPoint}");
NetworkStream stream = client.GetStream();

byte[] buffer = new byte[1024];

while (true)
{
    Console.Write("Enter message: ");
    string message = Console.ReadLine();

    byte[] data = System.Text.Encoding.UTF8.GetBytes(message);

    stream.Write(data, 0, data.Length);
}
