using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class UDPClient : ScriptableObject
{
    public IPEndPoint ipLocalEndPoint;
    public UdpClient client;
    public int port;
    public IPAddress Address;
    public string IP;

        /// <summary>Static reference to the instance of our DataManager</summary>
    public static Connection instance;

    public UDPClient() : base()
    {
        IP = "";
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                IP = ip.ToString();
            }
        }

        IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
        ipLocalEndPoint = new IPEndPoint(ipAddress, 19224);

        client = new UdpClient(ipLocalEndPoint.Port);
        

        port = ((IPEndPoint)client.Client.LocalEndPoint).Port;
    }
}
