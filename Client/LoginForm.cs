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
    public partial class LoginForm : Form
    {
        private Client client;

        public LoginForm()
        {
            InitializeComponent();
            client = new Client();
            HostName.Text = "localhost";
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            string hostName = HostName.Text;
            string accountNum = AccountNum.Text;

            try
            {
                client = new Client();
                if (await client.ConnectAsync(hostName, 12345))
                {
                    string response = await client.SendRequestAsync($"CONNECT {accountNum}");

                    if (response.StartsWith("CONNECTED"))
                    {
                        string userName = response.Substring("CONNECTED:".Length);
                        client.AccountNumber = int.Parse(accountNum);
                        client.UserName = userName;

                        ShopperForm shopperForm = new ShopperForm(client);
                        shopperForm.SetCustomerName(userName);
                        shopperForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your account number and try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}