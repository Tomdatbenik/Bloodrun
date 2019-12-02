using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    public Material Active;
    public Material Deactive;
    private bool activetrap;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        activetrap = false;
        
    }

    private void FixedUpdate()
    {
        timer++;
        if(timer == 50)
        {
            if (!activetrap)
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
            timer = 0;
        } 
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (activetrap == true)
    //    {
    //        other.transform.position = new Vector3(0f, 1f, 0f);
    //    }
    //}


}
