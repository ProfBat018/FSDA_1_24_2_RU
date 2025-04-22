using System.Net;
using System.Net.Sockets;
using System.Text;


int MulticastPort = 5000;
string MulticastGroupAddress = "239.0.0.222";


using var udpClient = new UdpClient();

udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, MulticastPort));

udpClient.JoinMulticastGroup(IPAddress.Parse(MulticastGroupAddress));

Console.WriteLine("Multicast Client запущен. Ожидание сообщений...");

while (true)
{
    IPEndPoint remoteEndPoint = new(IPAddress.Any, 0);
    byte[] buffer = udpClient.Receive(ref remoteEndPoint);
    string message = Encoding.UTF8.GetString(buffer);

    Console.WriteLine($"[Получено от {remoteEndPoint}]: {message}");
}