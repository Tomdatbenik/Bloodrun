using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public Connection connection;
    Thread receiveThread;
    // Start is called before the first frame update
    void Start()
    {
        connection = (Connection)FindObjectOfType(typeof(Connection));
        receiveThread = new Thread(
        new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    //CallBack
    private void ReceiveData()
    {

        try
        {
            connection.uDPClient.client.BeginReceive(new AsyncCallback(recv), null);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private void recv(IAsyncResult res)
    {
        Debug.Log(res); 
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 10922);
        byte[] received = connection.uDPClient.client.EndReceive(res, ref RemoteIpEndPoint);

        //Process codes
        Message msg = Message.FromJson(System.Text.Encoding.UTF8.GetString(Compressor.Decompress(received)));

        if(msg != null)
        {
            Debug.Log(msg.ToJson());
        }


        connection.uDPClient.client.BeginReceive(new AsyncCallback(recv), null);
    }
}
