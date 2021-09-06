using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandle
{
    public static void WelcomeReceived(int fromClient, Packet packet)
    {
        int clientIdCheck = packet.ReadInt();
        string username = packet.ReadString();
        string password = packet.ReadString();
        Debug.Log($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player{fromClient}.");
        if (fromClient != clientIdCheck)
        {
            Debug.Log($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID({clientIdCheck})!");
        }

        Server.clients[fromClient].SendIntoGame(username);
    }
    public static void PlayerMovement(int fromClient, Packet packet)
    {
        bool[] input = new bool[packet.ReadInt()];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = packet.ReadBool();
        }
        if (input[4])
        {
            Vector3 position = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();
            Server.clients[fromClient].player.SetInput(input, position, rotation);
        }
        else
        {
            Vector3 position = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();
            Server.clients[fromClient].player.SetInput(input, rotation);
        }

    }

    internal static void PlayerStopMovement(int fromClient, Packet packet)
    {
        bool stopMoving = packet.ReadBool();
        Server.clients[fromClient].player.isMoving = !stopMoving;
    }
    internal static void Login(int fromClient, Packet packet)
    {

    }
}
