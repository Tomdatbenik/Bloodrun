using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TCPConnection
{
    public NetworkStream stream;
    public TcpClient client;
    readonly int port = 10923;
    readonly string server = "Localhost";

    public TCPConnection()
    {

    }

    public void Connect()
    {
        this.client = new TcpClient(server, port);
        this.stream = client.GetStream();
    }

    public void Close()
    {
        stream.Close();
        client.Close();
    }
}
