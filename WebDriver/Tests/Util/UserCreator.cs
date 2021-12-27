using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Service
{
    public static class UserCreator
    {
        public static string login = "dima.dmitry.kulikov@gmail.com";
        public static string password = "AY%S&iDd9b4c.sg";

        public static User CreateUser()
        {
            return new User(login, password);
        }
    }
}
