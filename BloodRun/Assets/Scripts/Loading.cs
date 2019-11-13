using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Connection connection;
    // Start is called before the first frame update
    void Start()
    {
        connection = (Connection)FindObjectOfType(typeof(Connection));
    }

    // Update is called once per frame
    void Update()
    {       
        if(connection.LastReceivedUDPMessage != null)
        {
            Game game = Game.Fromjson(connection.LastReceivedUDPMessage);
            if (game != null)
            {
                bool allconnected = true;

                foreach(PlayerInfo player in game.GetPlayers)
                {
                    if(player.username != "null")
                    {
                        if (!player.Connected)
                        {
                            allconnected = false;
                        }
                    }
                }

                if(allconnected)
                {
                    SceneManager.LoadScene("Game", LoadSceneMode.Single);
                }

            }
        }
   
    }
}
