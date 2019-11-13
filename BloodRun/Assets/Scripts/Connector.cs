using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Connector : MonoBehaviour
{
    public Connection connection;
    UDPClient uDPClient;

    // Start is called before the first frame update
    void Start()
    {
        connection.StartTCPConnection();

        uDPClient = new UDPClient();
        connection.uDPClient = uDPClient;

        Message message = new Message(connection.Username, uDPClient.IP + ":" + uDPClient.port.ToString(), MessageType.Connect);

        connection.SendTCPMessage(message);


        //Wait for response

        NetworkStream ns = connection.tcpConnection.client.GetStream();

        byte[] bytes = new byte[128];
        int bytesRead = ns.Read(bytes, 0, bytes.Length);


        byte[] data = Compressor.Decompress(bytes);
        Message msg = Message.FromJson(Encoding.ASCII.GetString(data, 0, data.Length));

        if (msg.getType() == MessageType.Connect)
        {
            SceneManager.LoadScene("Loading", LoadSceneMode.Single);
        }
        else
        {

        }


        //try
        //{
        //    uDPClient.client.BeginReceive(new AsyncCallback(recv), null);
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e);
        //}



    }




    // Update is called once per frame
    void Update()
    {


    }

    void OnApplicationQuit()
    {
        Message message = new Message(connection.Username, "none", MessageType.Disconnect);

        connection.SendTCPMessage(message);

        this.connection.StopTCPConnection();
    }
}
