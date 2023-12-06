using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            if(ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y)) //calls the function that checks if x,y is in the ball and passes in startLinePosx and y, which is the coordinates of the mouse position
            {
                drawnLine = lineFactory.GetLine(ball.Position.ToUnityVector3(), startLinePos, 2f, Color.red); 
                //creates line from the position of the ball to the current position of the mouse. line is 2f thick and red
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(-(Camera.main.ScreenToWorldPoint(Input.mousePosition) - ball.Position.ToUnityVector3()));
            //magnitude of the vector is position of the ball subtracted from the mouse position, but negative, because i want the ball to move in the opposite direction of the pool cue's velocity
            ball.Velocity = v;
            Debug.Log(drawnLine.end - ball.Position.ToUnityVector2());
            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Update line end with the mouse position
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
