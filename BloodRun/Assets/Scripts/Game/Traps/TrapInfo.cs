using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInfo
{
    public TransformInfo transform;
    public bool activated;

    public static TrapInfo FromJson(JToken token)
    {
        TrapInfo trap = new TrapInfo();

        trap.transform = TransformInfo.FromJson(token.SelectToken("transform"));
        trap.activated = (bool)token.SelectToken("activated");

        return trap;
    }
}
