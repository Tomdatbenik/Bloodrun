using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo
{
    public TransformInfo transform;

    public static ProjectileInfo FromJson(JToken token)
    {
        ProjectileInfo projectile = new ProjectileInfo();

        projectile.transform = TransformInfo.FromJson(token.SelectToken("transform"));

        return new ProjectileInfo();
    }
}
