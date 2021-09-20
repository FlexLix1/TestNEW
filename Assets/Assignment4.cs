using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float speed = 5f;
    public Vector2 Charpos1, Charpos2;
    float diameter = 2;
    public Vector2 acceleration = new Vector2(0, 0);
    float AccelerationSpeed = 0.2f;
    float AccelerationDecrease = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Charpos1.x = Width / 2;
        Charpos1.y = Height / 2;

        Charpos2.x = Width / 2;
        Charpos2.y = Height / 3;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        Charpos1.x = Charpos1.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Charpos1.y = Charpos1.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Charpos2.x += acceleration.x;
        Charpos2.y += acceleration.y;

        if (Input.GetKey(KeyCode.D))
        {
            acceleration.x += AccelerationSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            acceleration.x -= AccelerationSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            acceleration.y += AccelerationSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            acceleration.y -= AccelerationSpeed * Time.deltaTime;
        }
        else
        {
            if (acceleration.x >= 0)
            {
                acceleration.x -= AccelerationDecrease * Time.deltaTime;
            }
            
            if (acceleration.x <= 0)
            {
                acceleration.x += AccelerationDecrease * Time.deltaTime;
            }
            
            if (acceleration.y <= 0)
            {
                acceleration.y += AccelerationDecrease * Time.deltaTime;
            }
            
            if (acceleration.y >= 0)
            {
                acceleration.y -= AccelerationDecrease * Time.deltaTime;
            }
        }

        Circle(Charpos1.x, Charpos1.y, diameter);
        Circle(Charpos2.x, Charpos2.y, diameter);

        Debug.Log("1:" + Charpos1);
        Debug.Log("2:" + Charpos2);
    }






}
