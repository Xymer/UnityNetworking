using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    [SerializeField] private GameObject localPlayerPrefab;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log($"Instance already exists, destroying{this.gameObject.name}");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int id, string username, Vector3 position, Quaternion rotation)
    {
        GameObject player;
        if (id == Client.instance.myID)
        {
            player = Instantiate(localPlayerPrefab,position,rotation);
        }
        else
        {
            player = Instantiate(playerPrefab, position, rotation);
        }
        
        player.GetComponent<PlayerManager>().id = id;
        player.GetComponent<PlayerManager>().username = username;
        players.Add(id, player.GetComponent<PlayerManager>());
        
    }
}
