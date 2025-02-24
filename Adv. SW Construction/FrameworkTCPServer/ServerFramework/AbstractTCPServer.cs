using System.Net;
using System.Net.Sockets;
using System.Xml;

namespace ServerFramework
{
    public abstract class AbstractTCPServer
    {
        private readonly int _port;
        private readonly string _serverName;
        private volatile bool _running = true;
        private readonly string _confFile = "MyConf.xml";

        protected AbstractTCPServer()
        {
            try
            {
                var path = Environment.GetEnvironmentVariable("AbstractServerConf");
                if (path == null)
                {
                    throw new ArgumentException("Invalid directory: path not found");
                }

                XmlDocument configDoc = new XmlDocument();
                configDoc.Load(Path.Combine(path, _confFile));

                XmlElement root = configDoc.DocumentElement ?? throw new InvalidOperationException("Invalid configuration file: Missing root element.");

                _serverName = root.SelectSingleNode("ServerName")?.InnerText.Trim() ?? throw new InvalidOperationException("ServerName not found in configuration.");
                _port = int.TryParse(root.SelectSingleNode("ServerPort")?.InnerText.Trim(), out int port)
                    ? port
                    : throw new InvalidOperationException("Invalid or missing ServerPort in configuration.");

                Logger.Instance.LogInformation("Configuration loaded successfully.");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError($"Error loading configuration: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Starts the server, listens for incoming connections, and handles clients asynchronously.
        /// </summary>
        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, _port);
            listener.Start();

            Logger.Instance.LogInformation($"{_serverName} started on port {_port}");

            Task.Run(() => StopServer());

            while (_running)
            {
                try
                {
                    if (listener.Pending())
                    {
                        TcpClient socket = listener.AcceptTcpClient();

                        Logger.Instance.LogInformation($"Client connected from (ip,port) = ({socket.Client.RemoteEndPoint})");

                        Task.Run(() => HandleClient(socket));
                    }
                    else
                    {
                        Thread.Sleep(2 * 1000);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogError($"Error in server loop: {ex.Message}");
                }
            }

            listener.Stop();
        }

        private void HandleClient(TcpClient socket)
        {
            var remoteEndPoint = socket.Client.RemoteEndPoint;
            try
            {
                using NetworkStream ns = socket.GetStream();
                using StreamReader sr = new StreamReader(ns);
                using StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                TcpServerWork(sr, sw);
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError($"Error handling client: {ex.Message}");
            }
            finally
            {
                Logger.Instance.LogInformation($"Client disconnected from (ip, port) = ({remoteEndPoint})");
            }
        }

        protected abstract void TcpServerWork(StreamReader sr, StreamWriter sw);

        private void SetRunningToFalse()
        {
            _running = false;
        }

        private void StopServer()
        {
            TcpListener stopListener = new TcpListener(IPAddress.Loopback, _port + 1);
            stopListener.Start();

            while (true)
            {
                try
                {
                    using TcpClient socket = stopListener.AcceptTcpClient();
                    using NetworkStream ns = socket.GetStream();
                    using StreamReader sr = new StreamReader(ns);
                    using StreamWriter sw = new StreamWriter(ns);
                    sw.AutoFlush = true;

                    string? command = sr.ReadLine();
                    if (command == "Shutdown Server")
                    {
                        Logger.Instance.LogInformation("Server shutting down.");

                        SetRunningToFalse();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogError($"Error in stop server loop: {ex.Message}");
                }
            }

            stopListener.Stop();
        }
    }
}
