using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public TCPConnection tcpConnection;
    TCPWriter tcpWriter;
    public UDPClient uDPClient;
    Thread receiveThread;

    public Message LastReceivedUDPMessage;
    public Game game;
    public string Username;
    public string ServerIp;

    private void Start()
    {
        receiveThread = new Thread(
        new ThreadStart(ReceiveDataUDP));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    public void StartTCPConnection()
    {
        tcpConnection = new TCPConnection(ServerIp);
        tcpConnection.Connect();
        tcpWriter = new TCPWriter(tcpConnection);
    }

    public void StopTCPConnection()
    {
        tcpConnection.Close();
    }

    public void SendTCPMessage(Message message)
    {
        tcpWriter.Send(message);
    }

    public void ConnectUDPSender()
    {
        this.uDPClient.client.Connect(ServerIp, 10922);
    }

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static Connection instance;

    /// <summary>Awake is called when the script instance is being loaded.</summary>
    void Awake()
    {
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(gameObject);
    }

    void OnApplicationQuit()
    {
        Message message = new Message(Username, "none", MessageTypes.Disconnect);

        instance.SendTCPMessage(message);

        StopTCPConnection();
    }
    //CallBack
    private void ReceiveDataUDP()
    {
        try
        {
            this.uDPClient.client.BeginReceive(new AsyncCallback(recvUDP), null);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    private void recvUDP(IAsyncResult res)
    {
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 10922);
        byte[] received = this.uDPClient.client.EndReceive(res, ref RemoteIpEndPoint);

        //Process codes
        Message msg = Message.FromJson(System.Text.Encoding.UTF8.GetString(Compressor.Decompress(received)));

        //SetGame to message content
        if (msg != null)
        {
            game = Game.Fromjson(msg);
        }

        this.uDPClient.client.BeginReceive(new AsyncCallback(recvUDP), null);
    }

}
