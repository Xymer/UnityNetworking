using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerSend
{
    public static void Welcome(int toClient, string msg)
    {
        using (Packet packet = new Packet((int)ServerPackets.welcome))
        {
            packet.Write(msg);
            packet.Write(toClient);

            SendTCPData(toClient, packet);
        }

    }
    public static void SpawnPlayer(int toClient, Player player)
    {
        using (Packet packet = new Packet((int)ServerPackets.spawnPlayer))
        {
            packet.Write(player.id);
            packet.Write(player.username);
            packet.Write(player.transform.position);
            packet.Write(player.transform.rotation);

            SendTCPData(toClient, packet);
        }
    }
    private static void SendUDPData(int toClient, Packet packet)
    {
        packet.WriteLength();

        Server.clients[toClient].udp.SendData(packet);
    }

    private static void SendUDPDataToAll(Packet packet)
    {
        packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            Server.clients[i].udp.SendData(packet);
        }
    }

    private static void SendUDPDataToAll(int exceptPacket, Packet packet)
    {
        packet.WriteLength();
        for (int i = 1; i <= Server.MaxPlayers; i++)
        {
            if (i != exceptPacket)
            {
                Server.clients[i].udp.SendData(packet);
            }
        }
    }

    internal static void PlayerPosition(Player player)
    {
        using (Packet packet = new Packet((int)ServerPackets.playerPosition))
        {
            packet.Write(player.id);
            packet.Write(player.transform.position);
            SendUDPDataToAll(packet);
        }
    }
    internal static void PlayerRotation(Player player)
    {
        using (Packet packet = new Packet((int)ServerPackets.playerRotation))
        {
            packet.Write(player.id);
            packet.Write(player.transform.rotation);
            SendUDPDataToAll(player.id, packet);
        }
    }


    private static void SendTCPDataToAll(Packet packet)
    {
        packet.WriteLength();
        for (int i = 0; i < Server.MaxPlayers; i++)
        {
            Server.clients[i].tcp.SendData(packet);
        }
    }

    private static void SendTCPDataToAll(int exceptPacket, Packet packet)
    {
        packet.WriteLength();
        for (int i = 0; i < Server.MaxPlayers; i++)
        {
            if (i != exceptPacket)
            {
                Server.clients[i].tcp.SendData(packet);
            }
        }
    }

    private static void SendTCPData(int toClient, Packet packet)
    {
        packet.WriteLength();
        Server.clients[toClient].tcp.SendData(packet);
    }
}
