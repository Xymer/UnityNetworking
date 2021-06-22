using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int fromClient, Packet packet)
        {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();
            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player{fromClient}.");
            if (fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID({clientIdCheck})!");
            }
            Server.clients[fromClient].SendIntoGame(username);
        }
        public static void PlayerMovement(int fromClient,Packet packet)
        {
            bool[] input = new bool[packet.ReadInt()];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = packet.ReadBool();
            }
            Quaternion rotation = packet.ReadQuaternion();

            Server.clients[fromClient].player.SetInput(input, rotation);
        }
    }
}
