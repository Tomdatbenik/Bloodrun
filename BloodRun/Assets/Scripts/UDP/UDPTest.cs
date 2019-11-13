//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.IO;
//using System.IO.Compression;

//public class UDPTest : MonoBehaviour
//{
//    // Start is called before the first frame update
//    private static int localPort;

//    // prefs
//    private string IP;  // define in init
//    public int port;  // define in init

//    // "connection" things
//    IPEndPoint remoteEndPoint;
//    UdpClient client;

//    // gui
//    string strMessage = "";

//    public Rigidbody rb;


//    // start from unity3d
//    public void Start()
//    {
//        init();
//        sendString("ping");
//        Debug.Log("ping");
//        Thread thread = new Thread(ReceiveData);
//        thread.Start();
//        thread.Join();
//        rb.MovePosition(rb.position + new Vector3(1, 1, 1));
//    }

//    // init
//    public void init()
//    {
//        // define
//        IP = "127.0.0.1";
//        port = 10922;

//        // ----------------------------
//        // Senden
//        // ----------------------------
//        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
//        client = new UdpClient();
//    }

//    // sendData
//    private void sendString(string message)
//    {
//        try
//        {
//            //if (message != "")
//            //{

//            // Daten mit der UTF8-Kodierung in das Binärformat kodieren.
//            byte[] data = Encoding.UTF8.GetBytes(message);

//            byte[] compressed = Compressor.Compress(data);

//            // Den message zum Remote-Client senden.
//            client.Send(compressed, compressed.Length, remoteEndPoint);
//            //}
//        }
//        catch (Exception err)
//        {
//            print(err.ToString());
//        }
//    }

//    private void ReceiveData()
//    {

//        bool received = false;
//        if (!received)
//            try
//            {
//                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
//                byte[] data = client.Receive(ref anyIP);

//                string text = Encoding.UTF8.GetString(Compressor.Decompress(data));

//                if (text == "pong")
//                {
//                    received = true;
//                    Debug.Log(text);
//                }
//            }
//            catch (Exception err)
//            {
//                print(err.ToString());
//            }

//    }
//}

