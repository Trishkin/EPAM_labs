using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class Account
    {
        private string login;
        private string password;

        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string getLogin()
        {
            return login;
        }

        public void setLogin(string login)
        {
            this.login = login;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}
