using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment6 : ProcessingLite.GP21
{
    RandomWalker Walker;

    void Start()
    {
        Walker = new RandomWalker((int)Width, (int)Height);
    }

    void Update()
    {
        Vector2 newPos = Walker.Movement();

        Point((newPos.x * 0.01f) + Walker.startPos.x, (newPos.y * 0.01f) + Walker.startPos.y);
    }
}
