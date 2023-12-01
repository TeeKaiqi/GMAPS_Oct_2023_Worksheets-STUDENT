using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public class Util
    {
        public static float FindDistance(HVector2D p1, HVector2D p2)
        {
            //return Mathf.Sqrt(Mathf.Pow(p2.x-p1.x,2)+Mathf.Pow(p2.y-p1.y,2));
            return Mathf.Sqrt((p2.x - p1.x * p2.x - p1.x) + (p2.y - p1.y * p2.y - p1.y));
        }
    }
    public bool IsCollidingWith(float x, float y)
    {
        float distance = Util.FindDistance(new HVector2D(transform.position),new HVector2D(x,y));
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //float displacementX = /*your code here*/;
        //float displacementY = /*your code here*/;

        //Position.x += /*your code here*/;
        //Position.y += /*your code here*/;

        transform.position = new Vector2(/*your code here*/);
    }
}

