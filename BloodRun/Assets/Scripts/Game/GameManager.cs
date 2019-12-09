using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Connection connection;

    public GameObject Spawnpoint;
    public GameObject Playerprefab;

    public GameObject AlwaysActiveTrap;
    public GameObject Darter;
    public GameObject RotatingDarter;
    public GameObject RotateTrap;
    public GameObject Spiketrap;

    public List<Material> playercolors;

    public CinemachineVirtualCamera cam;


    public List<GameObject> players;
    public List<GameObject> traps;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
        traps = new List<GameObject>();

        connection = (Connection)FindObjectOfType(typeof(Connection));
        int playernumber = 0;
        foreach(PlayerInfo player in connection.game.GetPlayers)
        {
            GameObject gameObject = Playerprefab;
            if(player.username != "null")
            {
                //look in properties who the player is.
                PlayerUsername username = gameObject.GetComponent(typeof(PlayerUsername)) as PlayerUsername;

                username.Username = player.username;
                gameObject = Instantiate(gameObject);
                if (player.username == connection.Username)
                {
                    cam.Follow = gameObject.transform;
                    cam.LookAt = gameObject.transform;
                    gameObject.tag = "Player";
                }
                else
                {
                    PlayerMovement playerMovement = gameObject.GetComponent(typeof(PlayerMovement)) as PlayerMovement;

                    Destroy(playerMovement);

                    gameObject.tag = "OtherPlayers";
                }

                gameObject.transform.position = new Vector3(float.Parse(player.transform.location.x), float.Parse(player.transform.location.y), float.Parse(player.transform.location.z));
                gameObject.transform.rotation = new Quaternion(float.Parse(player.transform.rotation.x), float.Parse(player.transform.rotation.y), float.Parse(player.transform.rotation.z), float.Parse(player.transform.rotation.w));

                PlayerDeath playerDeath = gameObject.GetComponent(typeof(PlayerDeath)) as PlayerDeath;
                playerDeath.Spawnpoint = Spawnpoint;

                players.Add(gameObject);
            }
        }

        foreach (TrapInfo trap in connection.game.GetTraps)
        {
            GameObject gameObject = null;
            switch (trap.type)
            {
                case TrapType.AlwaysActiveTrap:
                    gameObject = AlwaysActiveTrap;
                    break;
                case TrapType.RotateTrap:
                    gameObject = RotateTrap;
                    break;
                case TrapType.RotatingDarter:
                    gameObject = RotatingDarter;
                    break;
                case TrapType.Darter:
                    gameObject = Darter;
                    break;
                case TrapType.SpikeTrap:
                    gameObject = Spiketrap;
                    break;
            }

            gameObject = Instantiate(gameObject);

            if(trap.type == TrapType.AlwaysActiveTrap || trap.type == TrapType.SpikeTrap)
            {
                gameObject.transform.localScale = new Vector3(float.Parse(trap.scale.x), float.Parse(trap.scale.y), float.Parse(trap.scale.z));
            }

            gameObject.transform.position = new Vector3(float.Parse(trap.transform.location.x), float.Parse(trap.transform.location.y), float.Parse(trap.transform.location.z));
            gameObject.transform.rotation = new Quaternion(float.Parse(trap.transform.rotation.x), float.Parse(trap.transform.rotation.y), float.Parse(trap.transform.rotation.z), float.Parse(trap.transform.rotation.w));
            
            Debug.Log(trap.transform.location.x);

            traps.Add(gameObject);
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
                    float x = float.Parse(player.transform.location.x);
                    float y = float.Parse(player.transform.location.y);
                    float z = float.Parse(player.transform.location.z);

                    Rigidbody rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;

                    Vector3 location = new Vector3(x, y, z);

                    Debug.Log(location);

                    rb.MovePosition(location);
                    gameObject.transform.position = location;
                    rb.rotation = new Quaternion(float.Parse(player.transform.rotation.x), float.Parse(player.transform.rotation.y), float.Parse(player.transform.rotation.z), float.Parse(player.transform.rotation.w));
                }
            }
        }
    }
}
