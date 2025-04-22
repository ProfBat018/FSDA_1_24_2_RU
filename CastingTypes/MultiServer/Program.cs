using System.Net;
using System.Net.Sockets;
using System.Text;

int MulticastPort = 3003;
string MulticastGroupAddress = "239.0.0.222";

using var udpClient = new UdpClient();
var multicastEndpoint = new IPEndPoint(IPAddress.Parse(MulticastGroupAddress), MulticastPort);

Console.WriteLine("Multicast Server запущен. Введите сообщение:");

while (true)
{
    string? message = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(message)) break;

    byte[] buffer = Encoding.UTF8.GetBytes(message);
    udpClient.Send(buffer, buffer.Length, multicastEndpoint);

    Console.WriteLine($"[Отправлено]: {message}");
}

Console.WriteLine("Сервер завершил работу.");