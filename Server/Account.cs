using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Account
    {
        public int AccountNumber { get; }
        public string UserName { get; }

        public Account(int accountNumber, string userName)
        {
            AccountNumber = accountNumber;
            UserName = userName;
        }
    }
}
