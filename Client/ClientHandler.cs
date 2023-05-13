using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientHandler : IDisposable
    {
        private readonly TcpClient tcpClient;
        private readonly NetworkStream networkStream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;
        private readonly object streamLock = new object();

        public ClientHandler(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            networkStream = tcpClient.GetStream();
            reader = new StreamReader(networkStream, Encoding.UTF8);
            writer = new StreamWriter(networkStream, Encoding.UTF8) { AutoFlush = true };
        }

        public async Task<string> SendRequestAsync(string request)
        {
            string response;
            lock (streamLock)
            {
                writer.WriteLine(request);
                response = reader.ReadLine();
            }
            return response;
        }

        public void Dispose()
        {
            reader.Dispose();
            writer.Dispose();
            networkStream.Dispose();
        }
    }
}
