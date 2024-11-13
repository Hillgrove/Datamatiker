namespace P2PLib.Models
{
    public class FileEndPoint
    {
        public string IPAddress { get; set; } = string.Empty;
        public int Port { get; set; }

        public FileEndPoint()
        {
            // Default constructor
        }

        public override bool Equals(object? obj)
        {
            if (obj is not FileEndPoint other)
            {
                return false;
            }

            return IPAddress == other.IPAddress && Port == other.Port;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IPAddress, Port);
        }
    }
}