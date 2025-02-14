using System.Net.Sockets;
using System.Net;

namespace ServerFramework.TCPServer
{
    public abstract class AbstractTCPServer
    {
        private readonly int _port;
        private readonly string _serverName;
        private volatile bool running = true;

        protected AbstractTCPServer(int port, string serverName)
        {
            _port = port;
            _serverName = serverName;
        }

        /// <summary>
        /// Starts the server, listens for incoming connections, and handles clients asynchronously.
        /// </summary>
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, _port);
            listener.Start();

            Console.WriteLine($"{_serverName} started on port {_port}");

            Task.Run(() => StopServer());

            while (running)
            {
                if (listener.Pending())
                {
                    TcpClient socket = listener.AcceptTcpClient();
                    Console.WriteLine($"Client connected from (ip,port) = ({socket.Client.RemoteEndPoint})");
                    Task.Run(() => HandleClient(socket));
                }

                else
                {
                    Thread.Sleep(2*1000);
                }
            }

            listener.Stop();
        }

        private void HandleClient(TcpClient socket)
        {
            using NetworkStream ns = socket.GetStream();
            using StreamReader sr = new StreamReader(ns);
            using StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            TcpServerWork(sr, sw);
        }

        protected abstract void TcpServerWork(StreamReader sr, StreamWriter sw);

        private void SetRunningToFalse()
        {
            running = false;
        }

        private void StopServer()
        {
            TcpListener stopListener = new TcpListener(IPAddress.Loopback, _port + 1);
            stopListener.Start();
            
            while (true)
            {

                using TcpClient socket = stopListener.AcceptTcpClient();
                using NetworkStream ns = socket.GetStream();
                using StreamReader sr = new StreamReader(ns);
                using StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string? command = sr.ReadLine();
                if (command == "Shutdown Server")
                {
                    Console.WriteLine("Server shutting down.");
                    SetRunningToFalse();
                    break;
                }
            }

            stopListener.Stop();
        }
    }
}
