using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingObject : MonoBehaviour
{
    public Transform origin;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent(typeof(Rigidbody)) as Rigidbody;

        var magnitude = 2500;

        var force = transform.position - other.transform.position;

        force.Normalize();

        rb.AddForce(-force * magnitude);
    }
}
