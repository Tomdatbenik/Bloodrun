//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Net.Sockets;
//using UnityEngine;

//public class Test : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        Connect("localhost","connected");
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    static void Connect(string server, string message)
//    {
//        try
//        {
//            //Create a TcpClient.
//            //Note, for this client to work you need to have a TcpServer

//            //connected to the same address as specified by the server, port

//            //combination.

//           int port = 10923;
//           TcpClient client = new TcpClient(server, port);

//            //Translate the passed message into ASCII and store it as a Byte array.
//            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

//            //Get a client stream for reading and writing.

//            NetworkStream stream = client.GetStream();

//            //Send the message to the connected TcpServer.
//            stream.Write(data, 0, data.Length);

//            Console.WriteLine("Sent: {0}", message);

//            //Receive the TcpServer.response.
//            Message msg = new Message(message, MessageType.Connect);

//            //Buffer to store the response bytes.
//            data = Compressor.Compress(System.Text.Encoding.ASCII.GetBytes(JsonUtility.ToJson(msg)));
//            stream.Write(data, data.Length, data.Length);
//            stream.Flush();
//            //String to store the response ASCII representation.
//            String responseData = String.Empty;

//            //Read the first batch of the TcpServer response bytes.
//            Int32 bytes = stream.Read(data, 0, data.Length);
//            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
//            Console.WriteLine("Received: {0}", responseData);

//            //Close everything.
//            stream.Close();
//            client.Close();
//        }
//        catch (ArgumentNullException e)
//        {
//            Console.WriteLine("ArgumentNullException: {0}", e);
//        }
//        catch (SocketException e)
//        {
//            Console.WriteLine("SocketException: {0}", e);
//        }

//        Console.WriteLine("\n Press Enter to continue...");
//        Console.Read();
//    }
//}
