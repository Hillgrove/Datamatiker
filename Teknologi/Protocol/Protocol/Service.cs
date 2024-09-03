
namespace Protocol
{
    internal class Service
    {
        public void Send(string message, Receiver receiver)
        {
            receiver.Receive(message);
        }
    }
}
