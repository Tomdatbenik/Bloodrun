using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Connection connection;

    public GameObject Playerprefab;
    // Start is called before the first frame update
    void Start()
    {
        connection = (Connection)FindObjectOfType(typeof(Connection));

        foreach(PlayerInfo player in connection.game.GetPlayers)
        {
            GameObject gameObject = Playerprefab;
            if(player.username != "null")
            {
                //look in properties who the player is.
                PlayerUsername username = gameObject.GetComponent(typeof(PlayerUsername)) as PlayerUsername;
                username.Username = player.username;

                if (player.username == connection.Username)
                {
                    gameObject.tag = "Player";
                }
                else
                {
                    gameObject.tag = "OtherPlayers";
                }


                gameObject.transform.position = new Vector3(float.Parse(player.transform.location.x), float.Parse(player.transform.location.y), float.Parse(player.transform.location.z));
                gameObject.transform.rotation = new Quaternion(float.Parse(player.transform.rotation.x), float.Parse(player.transform.rotation.y), float.Parse(player.transform.rotation.z), float.Parse(player.transform.rotation.w));

                Instantiate(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
