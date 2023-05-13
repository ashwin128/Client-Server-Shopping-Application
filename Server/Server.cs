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
    public class Server
    {
        private readonly List<Product> products;
        private readonly List<Account> accounts;
        private readonly List<Order> orders;
        private TcpListener listener;
        private readonly List<TcpClient> connectedClients;
        private readonly object dataLock = new object();

        public Server()
        {
            products = InitializeProducts();
            accounts = InitializeAccounts();
            orders = new List<Order>();
            connectedClients = new List<TcpClient>();
        }

        public void Stop()
        {
            CloseAllClients();
            if (listener != null)
            {
                listener.Stop();
            }
        }

        public async Task StartAsync(int port, CancellationToken cancellationToken)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server started on port " + port);

            while (!cancellationToken.IsCancellationRequested)
            {
                if (listener.Pending())
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected");
                    lock (connectedClients)
                    {
                        connectedClients.Add(client);
                    }
                    _ = HandleClientAsync(client, cancellationToken);
                }
                else
                {
                    await Task.Delay(100);
                }
            }

            Stop();
        }


        private void CloseAllClients()
        {
            lock (connectedClients)
            {
                foreach (TcpClient client in connectedClients)
                {
                    client.Close();
                }
                connectedClients.Clear();
            }
        }

        private List<Product> InitializeProducts()
        {
            return new List<Product>
            {
                new Product("Apple", new Random().Next(1, 4)),
                new Product("Banana", new Random().Next(1, 4)),
                new Product("Pineapple", new Random().Next(1, 4)),
                new Product("Peach", new Random().Next(1, 4)),
                new Product("Printer", new Random().Next(1, 4)),
                new Product("Mouse", new Random().Next(1, 4)),
            };
        }

        private List<Account> InitializeAccounts()
        {
            return new List<Account>
            {
                new Account(1001, "John"),
                new Account(2002, "Sarah"),
                new Account(3003, "Emily"),
            };
        }

        public async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
        {
            ServerHandler handler = new ServerHandler(this, client, cancellationToken);
            lock (dataLock)
            {
                connectedClients.Add(client);
            }
            await handler.HandleClient();
            lock (dataLock)
            {
                connectedClients.Remove(client);
            }
        }

        public Account GetAccount(int accountNumber)
        {
            lock (dataLock)
            {
                foreach (Account account in accounts)
                {
                    if (account.AccountNumber == accountNumber)
                    {
                        return account;
                    }
                }
            }

            return null;
        }

        public List<Product> GetProducts()
        {
            lock (dataLock)
            {
                return new List<Product>(products);
            }
        }

        public Product GetProduct(string productName)
        {
            lock (dataLock)
            {
                foreach (Product product in products)
                {
                    if (product.Name == productName)
                    {
                        return product;
                    }
                }
            }

            return null;
        }

        public Order PlaceOrder(Account account, Product product, int quantity)
        {
            lock (dataLock)
            {
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;

                    int orderID = orders.Count + 1;
                    Order newOrder = new Order(orderID, account, product, quantity);
                    orders.Add(newOrder);

                    return newOrder;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Order> GetOrders(Account account)
        {
            List<Order> accountOrders = new List<Order>();
            foreach (Order order in orders)
            {
                if (order.Account.AccountNumber == account.AccountNumber)
                {
                    accountOrders.Add(order);
                }
            }

            return accountOrders;
        }
    }
}
