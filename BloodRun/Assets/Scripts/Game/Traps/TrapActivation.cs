using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    public Material Active;
    public Material Deactive;
    private bool activetrap;
    // Start is called before the first frame update
    void Start()
    {
        activetrap = false;
    }

    private void FixedUpdate()
    {
        if (activetrap)
        {
            GetComponent<Renderer>().material = Active;
            activetrap = true;
            gameObject.tag = "Trap";
        }
        else
        {
            GetComponent<Renderer>().material = Deactive;
            activetrap = false;
            gameObject.tag = "Deactive";
        }
    }

    public void activate()
    {
        activetrap = true;
    }

    public void deActivate()
    {
        activetrap = false;
    }
}
