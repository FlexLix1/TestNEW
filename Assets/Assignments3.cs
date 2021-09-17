using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignments3 : ProcessingLite.GP21
{

    public Vector2 circlePosition;
    public Vector2 offset;
    float diameter = 2;



    // Update is called once per frame
    void Update()
    {
        Background(0);
        //Line whom appears from the circle and ends at the position of the mouse 
        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
        }

        if (Input.GetMouseButtonUp(0))
        {
            offset = new Vector2(MouseX - circlePosition.x, MouseY - circlePosition.y);
            Debug.Log(offset);
        }

        if (Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
        }

        if (!Input.GetMouseButton(0))
        {
            if (circlePosition.x >= 13 ||  circlePosition.x <= 1)
            {
                offset *= -1;
            }
            if(circlePosition.y >= 13 || circlePosition.y <=1)
            {
                offset *= -1;
            }
        }

        circlePosition += offset * Time.deltaTime;
        Circle(circlePosition.x, circlePosition.y, diameter);
    }
}
