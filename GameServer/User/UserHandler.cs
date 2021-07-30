using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Users
{
    class UserHandler
    {
        private FileHandler fileHandler = new FileHandler("../Files/Users.txt");
        Dictionary<string, string> userValuePair = new Dictionary<string, string>();
        public UserHandler()
        {

        }
        public User GetUser(string username, string password)
        {
            if (fileHandler.SearchInFile(username + password))
            {
                FileHandler findData = new FileHandler($"../Files/UserData/{username}");
                
                return new User(username, password);
            }
            return null;
        }
        public User CreateUser(string username, string password)
        {
            //Todo: Check if user already exists in file, if not create new user
            return fileHandler.CreateUser(username,password);
        }
        public bool DoesUserExist(string username)
        {
            return fileHandler.SearchInFile(username);
        }
    }
}
