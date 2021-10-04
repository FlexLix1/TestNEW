using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignments2 : ProcessingLite.GP21
{
    // Start is called before the first frame update

    float spaceBetweenLines = 0.2f;
    float X2 = 1;
    float Y1 = 12;

    void Start()
    {
        Background(255, 255, 255);
        StrokeWeight(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
       

        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {

            if(X2 % 3 == 1)
            {
                Stroke(0, 0, 0);
            }
            else
            {
                Stroke(130, 130, 130);
            }

            float y = i * spaceBetweenLines;

            X2++;
            Y1--;

            Line(0, Y1, X2, 0);
        }
    }
}