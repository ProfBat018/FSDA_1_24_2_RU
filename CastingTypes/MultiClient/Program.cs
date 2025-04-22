using System.Net;
using System.Net.Sockets;
using System.Text;


int MulticastPort = 3003;
string MulticastGroupAddress = "239.0.0.222";


using var udpClient = new UdpClient();

udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, MulticastPort));

udpClient.JoinMulticastGroup(IPAddress.Parse(MulticastGroupAddress));

Console.WriteLine("Multicast Client запущен. Ожидание сообщений...");

while (true)
{
    byte[] buffer = new byte[1024];
    IPEndPoint remoteEndPoint = new(IPAddress.Any, 0);
    buffer = udpClient.Receive(ref remoteEndPoint);
    string message = Encoding.UTF8.GetString(buffer);

    Console.WriteLine($"[Получено от {remoteEndPoint}]: {message}");
}


static IPAddress GetLocalIPAddress()
{
    foreach (var netInterface in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
    {
        if (netInterface.AddressFamily == AddressFamily.InterNetwork)
        {
            return netInterface;
        }
    }

    throw new Exception("Local IPv4 address not found!");
}