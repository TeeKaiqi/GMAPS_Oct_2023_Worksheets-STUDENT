using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;
    
    private void Start()
    {
        if (IsCaptain)
        {
            OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
        }

    }

    float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        vector.x /= mag;
        vector.y /= mag;
        return new Vector3(vector.x, vector.y);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x + vectorA.y * vectorB.y);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i ++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
            toPlayer = toPlayer.normalized;
            //toPlayer = Normalise(toPlayer);

            //float dot = Dot(transform.forward, toPlayer);
            float dot = Vector3.Dot(transform.forward, toPlayer);
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            //Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.black); //draws rays from captain to every other player
        }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            Debug.Log(targetPlayer);
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach(SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}