using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GameServer.Users;

namespace GameServer
{
    class FileHandler
    {
        FileStream fileUserStream = null;
        StreamWriter streamUserWriter = null;
        StreamReader streamUserReader = null;

        string file = null;
        public FileHandler(string path)
        {

            fileUserStream = File.Open(path, FileMode.OpenOrCreate);


            streamUserWriter = new StreamWriter(fileUserStream);
            streamUserReader = new StreamReader(fileUserStream);
            file = streamUserReader.ReadToEnd();
            
        }
        public bool SearchInFile(string toSearchFor)
        {
            return file.Contains(toSearchFor);
        }
        public UserData GetData(string username)
        {
            UserData userData = new UserData();
            string userDataText = null;
            int startIndex = file.IndexOf(username);
            int endIndex = file.IndexOf("**", startIndex);
            userDataText = file.Substring(startIndex, endIndex - startIndex);

            return userData;
        }
        private void WriteUserData(string username)
        {
            string reading = " ";
            while (reading != null)
            {
                reading = streamUserReader.ReadLine();
                if (reading.Contains(username))
                {
                    streamUserWriter.WriteLine("test" + "**");
                    break;
                }
            }
        }
        public User CreateUser(string username, string password)
        {
            if (file.Contains(username))
            {
                return null;
            }
            
            streamUserWriter.WriteLine(username + password);


            return new User(username, password, new UserData());
        }
    }
}
