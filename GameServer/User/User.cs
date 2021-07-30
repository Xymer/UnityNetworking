using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GameServer.Users
{
    public class User
    {
        string username = null;
        string password = null; // Temporary until I can encrypt the password, Only use for testing.
        UserData userData;
       public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            userData = new UserData();
        }
        public User(string username, string password, UserData userData)
        {
            this.username = username;
            this.password = password;
            this.userData = userData;
        }

    }
}
