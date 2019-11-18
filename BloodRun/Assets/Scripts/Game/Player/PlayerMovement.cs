using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Connection connection;
    private Rigidbody Rigidbody;
    public int speed = 16;
    // Start is called before the first frame update
    void Start()
    {
        connection = (Connection)FindObjectOfType(typeof(Connection));

        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        MovePlayer();
        SendDataToServer();
    }

    public void MovePlayer()
    {
        Rigidbody.MovePosition(Rigidbody.position + new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed));
    }

    public void SendDataToServer()
    {
        PlayerUsername username = gameObject.GetComponent(typeof(PlayerUsername)) as PlayerUsername;
        if (connection.Username == username.Username)
        {
            PlayerInfo player = new PlayerInfo();

            player.username = connection.Username;

            player.transform.location.x = gameObject.transform.position.x.ToString();
            player.transform.location.y = gameObject.transform.position.y.ToString();
            player.transform.location.z = gameObject.transform.position.z.ToString();

            player.transform.rotation.x = gameObject.transform.rotation.x.ToString();
            player.transform.rotation.y = gameObject.transform.rotation.y.ToString();
            player.transform.rotation.z = gameObject.transform.rotation.z.ToString();
            player.transform.rotation.w = gameObject.transform.rotation.w.ToString();


            Message message = new Message(connection.Username, player.ToJson(), MessageType.Move);
            byte[] data = Compressor.Compress(System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message)));

            connection.uDPClient.client.Send(data, data.Length, connection.ServerIp, 10922);
        }
    }
}
