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

    public bool IsCollidingWith(float x, float y)
    {
        float distance = Util.FindDistance(Position, new HVector2D(x,y)); //Calculates the distance between the ball and x,y using the finddistance from Util script
        return distance <= Radius; //returns true if distance is smaller or equal to the radius, which means that the x,y is inside the ball
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
        float displacementX = Velocity.x * deltaTime; //calculates x axis displacement by multiplying the velocity x value by the delta time
        float displacementY = Velocity.y * deltaTime; //calculates y axis displacement by multiplying the velocity y valye by the delta time

        Position.x += displacementX; //adds the x axis displacement to position.x and makes that the new position.x value
        Position.y += displacementY; //adds the y axis displacement to position.y and makes that the new position.y value

        transform.position = new Vector2(Position.x, Position.y); //transforms position to the new x and y
    }
}

