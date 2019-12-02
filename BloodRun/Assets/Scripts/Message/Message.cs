using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public string sender;
    public string content;
    public MessageTypes type;

    //region Getters and Setters
    public string getContent()
    {
        return content;
    }

    public void setContent(string content)
    {
        this.content = content;
    }

    public MessageTypes getType()
    {
        return type;
    }

    public void setType(MessageTypes type)
    {
        this.type = type;
    }
    //endregion

    public Message()
    {
        content = "";
        type = MessageTypes.Connect;
    }

    public Message(string sender,string content, MessageTypes type)
    {
        this.sender = sender;
        this.content = content;
        this.type = type;
    }

   
    public string toString()
    {
        return "Content: " + this.content + ", Type: " + type.ToString() + ".";
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static Message FromJson(string json)
    {
        try
        {
            Message message = JsonConvert.DeserializeObject<Message>(json);
            if (message.sender != null || message.sender != "")
            {
                return message;
            }
            else
            {
                return null;
            }
            
        }
        catch
        {
            return null;
        }
      
    }
}
