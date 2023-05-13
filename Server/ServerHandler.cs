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
    public class ServerHandler
    {
        private readonly Server server;
        private readonly TcpClient client;
        private readonly CancellationToken cancellationToken;
        private Account connectedAccount = null;
        public ServerHandler(Server server, TcpClient client, CancellationToken cancellationToken)
        {
            this.server = server;
            this.client = client;
            this.cancellationToken = cancellationToken;
        }

        public async Task HandleClient()
        {
            string command = "";
            using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII))
            using (StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.ASCII))
            {
                try
                {
                    string request;
                    while (!cancellationToken.IsCancellationRequested && (request = await reader.ReadLineAsync()) != null)
                    {
                        string[] parts = request.Split(' ');
                        command = parts[0];

                        string response = ProcessRequest(request);
                        if (command == "GET_ORDERS")
                        {
                            Console.WriteLine("GET_ORDERS");
                            Console.WriteLine(response);
                        }
                        await writer.WriteLineAsync(response);
                        await writer.FlushAsync();
                    }
                }
                catch (IOException ex) when (cancellationToken.IsCancellationRequested)
                {
                    //  
                }
                catch (ObjectDisposedException ex) when (cancellationToken.IsCancellationRequested)
                {
                    // 
                }
            }
        }

        private string ProcessRequest(string request)
        {
            string[] parts = request.Split(' ');

            if (parts.Length == 0)
            {
                return "Invalid request";
            }

            string command = parts[0];

            switch (command)
            {
                case "CONNECT":
                    if (parts.Length == 2)
                    {
                        int accountNumber = int.Parse(parts[1]);
                        Account account = server.GetAccount(accountNumber);
                        if (account != null)
                        {
                            connectedAccount = account;
                            Console.WriteLine($"CONNECTED:{account.UserName}");
                            return "CONNECTED:" + account.UserName;
                        }
                        else
                        {
                            return "CONNECT_ERROR";
                        }
                    }
                    else
                    {
                        return "CONNECT_ERROR";
                    }


                case "GET_PRODUCTS":
                    StringBuilder productsInfo = new StringBuilder("PRODUCTS:");
                    for (int i = 0; i < server.GetProducts().Count; i++)
                    {
                        Product product = server.GetProducts()[i];
                        productsInfo.Append($"{product.Name},{product.Quantity}");
                        if (i < server.GetProducts().Count - 1)
                        {
                            productsInfo.Append("|");
                        }
                    }
                    Console.WriteLine("GET_PRODUCTS");
                    Console.WriteLine(productsInfo.ToString());
                    return productsInfo.ToString();

                case "GET_ORDERS":
                    if (connectedAccount != null)
                    {
                        StringBuilder ordersInfo = new StringBuilder("ORDERS:");
                        List<Order> accountOrders = server.GetOrders(connectedAccount);
                        for (int i = 0; i < accountOrders.Count; i++)
                        {
                            Order order = accountOrders[i];
                            ordersInfo.Append($"{order.Product.Name},{order.Quantity},{order.Account.UserName}");
                            if (i < accountOrders.Count - 1)
                            {
                                ordersInfo.Append("|");
                            }
                        }
                        Console.WriteLine(ordersInfo.ToString());
                        return ordersInfo.ToString();
                    }
                    else
                    {
                        return "NOT_CONNECTED";
                    }

                case "PURCHASE":
                    if (parts.Length == 2)
                    {
                        string productName = parts[1];
                        Product orderProduct = server.GetProduct(productName);

                        if (orderProduct != null)
                        {
                            if (orderProduct.Quantity > 0)
                            {
                                server.PlaceOrder(connectedAccount, orderProduct, 1);
                                Console.WriteLine("PURCHASE:" + orderProduct.Name);
                                Console.WriteLine("DONE");
                                return $"PURCHASE_SUCCESS:{orderProduct.Name}";
                            }
                            else
                            {
                                return "NOT_AVAILABLE";
                            }
                        }
                        else
                        {
                            return "NOT_VALID";
                        }
                    }
                    else
                    {
                        return "NOT_VALID";
                    }

                case "DISCONNECT":
                    return "";

                default:
                    return "Unknown command";
            }
        }
    }
}
