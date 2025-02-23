using ServerFramework;

namespace TCPServerImplementation
{
    public class MyTCPServer : AbstractTCPServer
    {
        public MyTCPServer(int port, string serverName) : base(port, serverName)
        {
        }

        protected override void TcpServerWork(StreamReader sr, StreamWriter sw)
        {
            string? line = sr.ReadLine();
            if (line == null)
            {
                throw new NotImplementedException();
            }

            int wordCount = line.Split().Length;
            sw.WriteLine($"Number of words in \"{line}\" is {wordCount}");
        }
    }
}
