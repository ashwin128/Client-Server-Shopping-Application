using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    public class Client
    {
        private TcpClient tcpClient;
        private ClientHandler handler;
        private object sendRequestLock = new object();
        public int AccountNumber { get; set; }
        public string UserName { get; set; }

        public async Task<bool> ConnectAsync(string host, int port)
        {
            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(host, port);
                handler = new ClientHandler(tcpClient);
                return true;
            }
            catch (SocketException ex)
            {
                throw new Exception("Server is unavailable.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to the server.", ex);
            }
        }

        public async Task<string> SendRequestAsync(string request)
        {
            if (handler != null)
            {
                Task<string> sendRequestTask = Task.Run(() =>
                {
                    lock (sendRequestLock)
                    {
                        return handler.SendRequestAsync(request);
                    }
                });

                return await sendRequestTask;
            }

            return "Not connected";
        }

        public async Task DisconnectAsync()
        {
            await handler?.SendRequestAsync("DISCONNECT");
            handler?.Dispose();
            tcpClient?.Close();
            tcpClient = null;
            handler = null;
        }
    }
}
