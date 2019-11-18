using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Connection connection;

    public GameObject Playerprefab;

    public List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
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

                gameObject = Instantiate(gameObject);

                players.Add(gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        foreach (PlayerInfo player in connection.game.GetPlayers)
        {



            foreach(GameObject gameObject in players)
            {
                //look in properties who the player is.
                PlayerUsername username = gameObject.GetComponent(typeof(PlayerUsername)) as PlayerUsername;

                if (username.Username == player.username && username.Username != connection.Username)
                {
                    Debug.Log(float.Parse(player.transform.location.y));
                    Debug.Log(float.Parse(player.transform.location.x));


                    Rigidbody rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;

                    Vector3 location = new Vector3(float.Parse(player.transform.location.x), float.Parse(player.transform.location.y), float.Parse(player.transform.location.z)).normalized;
                    Debug.Log(username.Username + ":" + location);


                    rb.MovePosition(location);
                    gameObject.transform.position = location;
                    rb.rotation = new Quaternion(float.Parse(player.transform.rotation.x), float.Parse(player.transform.rotation.y), float.Parse(player.transform.rotation.z), float.Parse(player.transform.rotation.w));
                }
            }
        }
    }


}
