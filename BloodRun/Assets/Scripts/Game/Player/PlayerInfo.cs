using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo 
{
    public string username;
    public TransformInfo transform;
    public bool Connected = false;

    public static PlayerInfo FromJson(JToken jToken)
    {
        PlayerInfo player = new PlayerInfo();

        player.username = (string)jToken.SelectToken("username");
        player.transform = TransformInfo.FromJson(jToken.SelectToken("transform"));
        player.Connected = (bool)jToken.SelectToken("connected");

        return player;
    }
}
