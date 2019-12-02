using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDart : MonoBehaviour
{
    public GameObject dart;
    private int timer;
    public int shootrate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if(timer == shootrate)
        {
            Instantiate(dart);
            dart.transform.position = gameObject.transform.position;
            dart.transform.rotation = gameObject.transform.rotation;
            timer = 0;
        }
    }
}
