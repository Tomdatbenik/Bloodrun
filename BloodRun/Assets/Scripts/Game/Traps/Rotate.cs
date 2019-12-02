using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotatex = false;
    public bool rotatey = false;
    // Update is called once per frame
    void Update()
    {
        if (rotatex == true)
        {
            transform.Rotate(6.0f * 20 * Time.deltaTime, 0, 0);
        }
        else if(rotatey == true)
        {
            transform.Rotate(0f, 6.0f * 20 * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0, 0, 6.0f * 20 * Time.deltaTime);
        }

        
    }
}
