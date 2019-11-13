
using Newtonsoft.Json;
using System;
using UnityEngine;

public class TCPWriter
{
    private TCPConnection connection;

    public TCPWriter(TCPConnection connection)
    {
        this.connection = connection;
    }

    public void Send(Message message)
    {
        //Send write
        if (this.connection.stream.CanWrite)
        {
            string test = JsonConvert.SerializeObject(message);
            byte[] data = Compressor.Compress(System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message)));
            this.connection.stream.Write(data, 0, data.Length);
            this.connection.stream.Flush();
        }
        else
        {
            Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
        }
    }


}
