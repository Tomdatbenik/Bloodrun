using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    //TODO Create properties ip and port

    private List<PlayerInfo> players;
    private List<ProjectileInfo> projectiles;
    private List<TrapInfo> traps;

    public List<PlayerInfo> GetPlayers { get { return players; } }
    public List<ProjectileInfo> GetProjectiles { get { return projectiles; } }
    public List<TrapInfo> GetTraps { get { return traps; } }

    public Game()
    {
        players = new List<PlayerInfo>();
        projectiles = new List<ProjectileInfo>();
        traps = new List<TrapInfo>();
    }

    public static Game Fromjson(Message message)
    {
        try
        {
            Game game = new Game();

            JObject jObject = JObject.Parse(message.getContent());

            //TODO get jObject from object.
            JToken Jplayers = jObject.SelectToken("players");

            for (int i = 1; i < 5; i++)
            {
                Debug.Log(Jplayers.SelectToken("player_" + i));

                JToken Jplayer = Jplayers.SelectToken("player_" + i);
                PlayerInfo player = PlayerInfo.FromJson(Jplayer);
                game.players.Add(player);
            }

            IEnumerable<JToken> Projectiles = jObject.SelectToken("projectiles");

            foreach (JToken item in Projectiles)
            {
                game.projectiles.Add(ProjectileInfo.FromJson(item));
            }

            IEnumerable<JToken> traps = jObject.SelectToken("traps");

            foreach (JToken item in traps)
            {
                game.traps.Add(TrapInfo.FromJson(item));
            }

            return game;

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return null;
        }
    }
}
