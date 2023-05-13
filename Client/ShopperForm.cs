using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ShopperForm : Form
    {
        private Client client;

        public ShopperForm(Client client)
        {
            InitializeComponent();
            this.client = client;
            LoadProducts();
        }

        public void SetCustomerName(string name)
        {
            Namelbl.Text = "Welcome " + name;
        }

        private async void LoadProducts()
        {
            string response = await client.SendRequestAsync("GET_PRODUCTS");

            if (!response.StartsWith("PRODUCTS:"))
            {
                MessageBox.Show($"Error getting products. Server response: {response}");
                return;
            }

            string[] productData = response.Substring("PRODUCTS:".Length).Split('|');
            List<string> productList = new List<string>();

            foreach (string data in productData)
            {
                string[] parts = data.Split(',');
                string productName = parts[0];
                int quantity = int.Parse(parts[1]);

                productList.Add($"{productName}, {quantity}");
            }

            ProductList.Items.Clear();
            foreach (string item in productList)
            {
                ProductList.Items.Add(item);
            }
        }


        private async void Purchasebth_Click(object sender, EventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                string[] selectedItem = ProductList.SelectedItem.ToString().Split(',');
                string productName = selectedItem[0].Trim();

                string response = await client.SendRequestAsync($"PURCHASE {productName}");

                if (response.StartsWith("PURCHASE_SUCCESS"))
                {
                    MessageBox.Show($"You have successfully purchased {productName}!");
                    LoadProducts();
                    await LoadOrdersAsync();
                }
                else if (response.StartsWith("NOT_AVAILABLE"))
                {
                    MessageBox.Show("Product is no longer available.");
                }
                else
                {
                    MessageBox.Show($"Error processing the purchase. Server response: {response}");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to purchase.");
            }
        }


        private async Task LoadOrdersAsync()
        {
            try
            {
                string response = await client.SendRequestAsync("GET_ORDERS");

                if (!response.StartsWith("ORDERS:"))
                {
                    MessageBox.Show($"Error getting orders. Server response: {response}");
                    return;
                }

                string[] orderData = response.Substring("ORDERS:".Length).Split('|');
                List<string> orderList = new List<string>();

                foreach (string data in orderData)
                {
                    string[] parts = data.Split(',');
                    string productName = parts[0];
                    int quantity = int.Parse(parts[1]);
                    string buyerName = parts[2];

                    orderList.Add($"{productName}, {quantity}, {buyerName}");
                }

                ListBox.Items.Clear();
                foreach (string item in orderList)
                {
                    ListBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting orders: " + ex.Message);
            }
        }
        private async void ShopperForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            await client.DisconnectAsync();
            Application.ExitThread();
        }

    }

}
