
using System.Net;
using System.Net.Sockets;
using System.Text;

using (UdpClient socket = new UdpClient())
{
    socket.Client.Bind(new IPEndPoint(IPAddress.Any, 5005));
    IPEndPoint clientEndPoint = null;
    byte[] received = socket.Receive(ref clientEndPoint);
    string stringResult = Encoding.UTF8.GetString(received);
}