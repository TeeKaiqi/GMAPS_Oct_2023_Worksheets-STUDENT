using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force; //vector3 public property force
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody component
        rb.AddForce(force, ForceMode.Impulse); //add impulse force once 
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position); //prints the position of the sphere in the debug log
    }
}

//This follows Newton's first law because after the initial push, the object kept moving at a consistent speed.

