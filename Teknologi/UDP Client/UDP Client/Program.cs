
using System.Net.Sockets;
using System.Text;

using (UdpClient socket = new UdpClient())
{
    byte[] data = Encoding.UTF8.GetBytes("Hello, world!");
    socket.Send(data, data.Length, "localhost", 5005);

}