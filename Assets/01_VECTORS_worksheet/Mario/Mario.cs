using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = planet.transform.position - rb.transform.position;
        moveDir = new Vector3(gravityDir.y, -gravityDir.x, 0f);
        moveDir = moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(-Vector3.up, gravityNorm, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(rb.transform.position, moveDir, Color.red);

        DebugExtension.DebugArrow(rb.transform.position, gravityDir, Color.blue);
    }
}


