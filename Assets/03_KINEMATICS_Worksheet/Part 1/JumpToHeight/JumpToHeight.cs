using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //gets the rigidbody component
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        float u = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height); //using the third equation
        //initial position of the cube is from the ground, that is why velocity is 0 and the equation is -2 times the gravity and height
        rb.velocity = new Vector3(0, u, 0); //the velocity is the new vector with u as the y value becuse the cube is just jumping and the x and z values dont change
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); //calls the jump function
        }
    }
}

