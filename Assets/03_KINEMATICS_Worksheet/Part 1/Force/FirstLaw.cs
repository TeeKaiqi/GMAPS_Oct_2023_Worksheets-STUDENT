using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

//This follows Newton's first law because after the initial push, the object kept moving at a consistent speed.

