using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int port = 12345;

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Server server = new Server();
            Task serverTask = server.StartAsync(port, cancellationTokenSource.Token);

            Console.WriteLine("Press 'Q' to shut down");

            while (Console.ReadKey(true).Key != ConsoleKey.Q) { }

            cancellationTokenSource.Cancel();
            await serverTask;
            Console.WriteLine("Server stopped");
        }
    }  
}