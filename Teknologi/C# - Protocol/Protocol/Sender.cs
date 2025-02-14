
namespace Protocol
{
    internal class Sender
    {
        public void Send(string message, Receiver receiver)
        {
            Service service = new Service();
            service.Send(message, receiver);
        }
    }
}
