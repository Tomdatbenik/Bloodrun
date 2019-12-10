using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{

    public GameObject pushPrefab;

    private bool pushing;

    private void Start()
    {
        pushPrefab.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            push();
        }

        if (pushing)
        {
            pushPrefab.SetActive(true);
            pushing = false;
        }
        else
        {
            pushPrefab.SetActive(false);
        }
    }

    public void push()
    {
        pushing = true;
    }
}
