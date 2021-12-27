using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Service
{
    public static class AccountCreator
    {
        public static string loginAccount = "14649788";
        public static string passwordAccount = "i4uLxpj";

        public static Account CreateAccount()
        {
            return new Account(loginAccount, passwordAccount);
        }
    }
}
