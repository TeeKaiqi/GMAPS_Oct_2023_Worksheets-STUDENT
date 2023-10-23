using System.Collections.Generic;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY; 
    

    private void Start()
    {
        maxX = 5f; maxY = 5f;
        //Question2a();
        //Question2b(20);
        //Question2d();
        //Question2e(20);
        Question3a();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight; 

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0); //states the starting coordinates of the line
        endPt = new Vector2(2, 3); //states the end coordinates of the line

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black); //gets an active line with the start and end points, thickness and colour
        drawnLine.EnableDrawing(true); //enable the line

        Vector2 vec2 = endPt - startPt; //calculates magnitude
        Debug.Log("Magnitude = " + vec2.magnitude); //prints magnitude 
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i ++) //for loop to loop n times
        {
            CalculateGameDimensions();

            startPt = new Vector2(
                Random.Range(-maxX, maxX), //x axis of the vector2 is chosen from a random number between -5 and 5
                Random.Range(-maxY, maxY));

             endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);

            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            float x = Random.Range(-maxX, maxX);
            float y = Random.Range(-maxY, maxY);
            float z = Random.Range(-maxX, maxX);

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(x, y, z),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = new HVector2D(a.x+b.x, a.y+b.y);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(b.ToUnityVector3(), c.ToUnityVector3(), Color.white, 60f);

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
